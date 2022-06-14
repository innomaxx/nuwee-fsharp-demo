
module MaxInno.FSharpDemo.Chapters.UnitsOfMeasure

open System
open MaxInno.Console.Menu
open MaxInno.Console.Utils

// only fp and signed integer values
[<Measure>] type cm
[<Measure>] type ml = cm^3

[<Measure>] type g
[<Measure>] type kg
[<Measure>] type m
[<Measure>] type s

[<Measure>] type N = kg m / s^2
[<Measure>] type Pa = N / m^2

[<Measure>] type degC // temperature, Celsius/Centigrade
[<Measure>] type degF // temperature, Fahrenheit

let convertNewtonsToPascals (value: float<N>, square: float<m^2>): float<Pa> = value / square
let convertCelsiusToFahrenheit (temp: float<degC>): float<degF> = 9.0<degF> / 5.0<degC> * temp + 32.0<degF>
let convertFahrenheitToCelsius (temp: float<degF>): float<degC> = 5.0<degC> / 9.0<degF> * (temp - 32.0<degF>)

let getMenu() =
    ConsoleMenu(
        title = "Робота з одиницями вимiрювання",
        entries = [
            {
                title = "Конвертацiя температури"
                executor = fun() ->
                    let temp = readUserFloat32OrThrow("Введiть температуру для конвертацiї")
                    let convertMode = readUserInt32OrThrow("Введiть режим [1-C2F, 2-F2C]")
                    
                    let result =
                        match convertMode with
                        | 1 -> float (convertCelsiusToFahrenheit(
                             LanguagePrimitives.FloatWithMeasure<degC> (float temp)))
                        | 2 -> float (convertFahrenheitToCelsius(
                             LanguagePrimitives.FloatWithMeasure<degF> (float temp)))
                        | _ -> raise (ArgumentException("операцiя не пiдтримується"))
                        
                    printfn "\n Результат: %s" (result.ToString())
            }
            {
                title = "Конвертацiя: Ньютони в Паскалi"
                executor = fun() ->
                    let rawNewtons = readUserFloat32OrThrow("Введiть Ньютони")
                    let rawSide = readUserFloat32OrThrow("Введiть сторону площi")
                    
                    let square = float (pown rawSide 2)
                    let newtons: float<N> = LanguagePrimitives.FloatWithMeasure<N> (float rawNewtons)
                    let square: float<m^2> = LanguagePrimitives.FloatWithMeasure<m^2> (float square)
                    
                    let pascals: float<Pa> = convertNewtonsToPascals(newtons, square)
                    
                    printfn "\n Результат: %s Па" (pascals.ToString()) 
            }
        ],
        isSubMenu = true)