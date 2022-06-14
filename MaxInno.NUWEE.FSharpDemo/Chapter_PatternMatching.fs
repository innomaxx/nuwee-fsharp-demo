
module MaxInno.FSharpDemo.Chapters.PatternMatching

open MaxInno.Console.Menu
open MaxInno.Console.Utils

type Point = {
    x: float32
    y: float32
    z: float32
}

let getMenu() =
    ConsoleMenu(
        title = "Вiдповiднiсть шаблону",
        entries = [
            {
                title = "Обрахунок чисел Фiбоначчi"
                executor = fun() ->
                    let rec fib n =
                        match n with
                        | 0 -> 0
                        | 1 -> 1
                        | _ -> fib (n-1) + fib (n-2)
                        
                    let limit = readUserInt32OrThrow("Введiть верхнiй порiг")
                    
                    printfn ""
                    for i = 1 to limit do
                        printfn " Число %d: %d" i (fib i)
            }
            {
                title = "Визначити пору року з введеного мiсяця"
                executor = fun() ->
                    let month = readRawUserInputOrThrow("Введiть мiсяць")
                    let season =
                        match month with
                        | "грудень" | "січень" | "лютий" -> "зима"
                        | "березень" | "квітень" | "травень" -> "весна"
                        | "червень" | "липень" | "серпень" -> "лiто"
                        | "вересень" | "жовтень" | "листопад" -> "осiнь"
                        | _ -> ""
                        
                    printfn "\n %s" (if season = "" then "Неправильний мiсяць" else $"Пора року: {season}")
            }
            {
                title = "Порiвняння чисел"
                executor = fun() ->
                    let num1 = readUserInt32OrThrow("Введiть число 1")
                    let num2 = readUserInt32OrThrow("Введiть число 2")
                    
                    let result = function
                        | num1, num2 when num1 > num2 -> "число 1 є бiльшим за число 2"
                        | num1, num2 when num1 < num2 -> "число 1 є меншим за число 2"
                        | num1, num2 when num1 = num2 -> "число 1 дорiвнює числу 2"
                        | _ -> "помилка"
                    
                    let argTuple = (num1, num2)
                    printfn "\n Результат: %s" (result argTuple)
            }
            {
                title = "Опис положення точки (операцiї з записами)"
                executor = fun() ->
                    let axisX = readUserFloat32OrThrow("Введiть координату X")
                    let axisY = readUserFloat32OrThrow("Введiть координату Y")
                    let axisZ = readUserFloat32OrThrow("Введiть координату Z")
                    
                    let evaluatePoint(point: Point): string =
                        match point with
                        | { x = 0.0f; y = 0.0f; z = 0.0f } -> "на початках координат"
                        | { x = axisX; y = 0.0f; z = 0.0f } -> "на осi X (абсцис)"
                        | { x = 0.0f; y = axisY; z = 0.0f } -> "на осi Y (ординат)"
                        | { x = 0.0f; y = 0.0f; z = axisZ } -> "на осi Z (аплiкат)"
                        | _ -> $"за адресою ({axisX}; {axisY}; {axisZ})"
                    
                    printfn "\n Точка знаходиться %s" (evaluatePoint { x = axisX; y = axisY; z = axisZ })
            }
        ],
        isSubMenu = true)