// For more information see https://aka.ms/fsharp-console-apps

module Main

open MaxInno.FSharpDemo.Chapters
open MaxInno.Console.Menu

let entries = [
    {
        title = "Цикли"
        executor = fun() ->
            Loops.getMenu().loop()
    }
    {
        title = "Послiдовностi"
        executor = fun() ->
            Sequences.getMenu().loop()
    }
    {
        title = "Pattern matching"
        executor = fun() ->
            PatternMatching.getMenu().loop()
    }
    {
        title = "ООП: структури"
        executor = fun() ->
            Structs.getMenu().loop()
    }
    {
        title = "ООП: наслiдування"
        executor = fun() ->
            Inheritance.getMenu().loop()
    }
    {
        title = "Перелiчення"
        executor = fun() ->
            Enumerations.getMenu().loop()
    }
    {
        title = "Одиницi вимiрювання"
        executor = fun() ->
            UnitsOfMeasure.getMenu().loop()
    }
    {
        title = "Постачальники типiв"
        executor = fun() ->
            TypeProviders.getMenu().loop()
    }
    {
        title = "Discriminated Unions"
        executor = fun() ->
            DiscriminatedUnions.getMenu().loop()
    }
    {
        title = "Computation Expressions"
        executor = fun() ->
            ComputationExpressions.getMenu().loop()
    }
]

ConsoleMenu(title = "Демонстрацiя мови програмування F#", entries = entries).loop()

//        let t = Seq.map (fun i -> i % 2) [1;2;3;4]
//        let sum = Seq.sum(t)
//        printfn $"%i{sum}"

//type ComplexNumberClass(x: float32, y: float32) =
//    member this.x = x
//    member this.y = y
//    
//    static member (+) (num1: ComplexNumberClass, num2: ComplexNumberClass) =
//        ComplexNumberClass(num1.x + num2.x, num1.y + num2.y)
//    
//    static member (-) (num1: ComplexNumberClass, num2: ComplexNumberClass) =
//        ComplexNumberClass(num1.x - num2.x, num1.y - num2.y)
//    
//    override this.ToString() =
//        let x = this.x.ToString("N2")
//        let y = this.y.ToString("N2")
//        $"ComplexNumber [x={x}; y={y}]"