
module MaxInno.FSharpDemo.Chapters.Structs

open MaxInno.Console.Menu
open MaxInno.Console.Utils

type Line =
    struct
        val X1: float32
        val Y1: float32
        val X2: float32
        val Y2: float32
        
        new (x1, y1, x2, y2) =
            { X1 = x1; Y1 = y1; X2 = x2; Y2 = y2 }
            
        member this.getLength() =
            let square value = value * value
            sqrt(square(this.X1 - this.X2) + square(this.Y1 - this.Y2))
            
        override this.ToString() =
            $"Line [x1={this.X1}; y1={this.Y1}; x2={this.X2}; y2={this.Y2}]"
    end
    
type ComplexNumber =
    struct
        val x: float32
        val y: float32
        
        new (x, y) = { x = x; y = y }
        
        static member (+) (num1: ComplexNumber, num2: ComplexNumber) =
            ComplexNumber(num1.x + num2.x, num1.y + num2.y)
        
        static member (-) (num1: ComplexNumber, num2: ComplexNumber) =
            ComplexNumber(num1.x - num2.x, num1.y - num2.y)
        
        override this.ToString() =
            let x = this.x.ToString("N2")
            let y = this.y.ToString("N2")
            $"ComplexNumber [x={x}; y={y}]"
    end

let getMenu() =
    ConsoleMenu(
        title = "Робота зi структурами",
        entries = [
            {
                title = "Знайти довжину точки"
                executor = fun() ->
                    let x1 = readUserFloat32OrThrow("Введiть X1")
                    let y1 = readUserFloat32OrThrow("Введiть Y1")
                    let x2 = readUserFloat32OrThrow("Введiть X2")
                    let y2 = readUserFloat32OrThrow("Введiть Y2")
                    
                    let line = Line(x1, y1, x2, y2)
                    printfn $"\n %s{line.ToString()}"
                    printfn " Довжина лiнiї: %.2f" (line.getLength())
            }
            {
                title = "Операцiї з комплексними числами"
                executor = fun() ->
                    let num1_X = readUserFloat32OrThrow("Введiть X для числа 1")
                    let num1_Y = readUserFloat32OrThrow("Введiть Y для числа 1")
                    let num2_X = readUserFloat32OrThrow("Введiть X для числа 2")
                    let num2_Y = readUserFloat32OrThrow("Введiть Y для числа 2")
                    
                    let num1 = ComplexNumber(num1_X, num1_Y)
                    let num2 = ComplexNumber(num2_X, num2_Y)
                    
                    let operation = readRawUserInputOrThrow("Введiть потрiбну операцiю")
                    let computedResponse =
                        match operation with
                        | "+" -> $"num1 + num2 -> {num1 + num2}"
                        | "-" -> $"num1 - num2 -> {num1 - num2}"
                        | _ -> ""
                        
                    printfn "\n %s" (if computedResponse = "" then "Оператор не пiдтримується" else computedResponse)
            }
        ],
        isSubMenu = true)