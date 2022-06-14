
module MaxInno.FSharpDemo.Chapters.DiscriminatedUnions

open MaxInno.Console.Menu
    
type Shape =
    | Rectangle of width: float * length: float
    | Circle of radius: float
    | Prism of width: float * float * height: float

let getMenu() =
    ConsoleMenu(
        title = "Робота з розмiченими об'єднаннями",
        entries = [
            {
                title = "Знайти ширину кола"
                executor = fun() ->
                    
                    let s: Shape = Circle(10.0)
                    let getShapeWidth shape =
                        match shape with
                        | Rectangle(width = w) -> w
                        | Circle(radius = r) -> 2. * r
                        | Prism(width = w) -> w
                        
                    printfn "\n Ширина: %.2f" (getShapeWidth s)
            }
        ],
        isSubMenu = true)