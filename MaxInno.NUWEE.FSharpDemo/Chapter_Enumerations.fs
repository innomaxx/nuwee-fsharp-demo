
module MaxInno.FSharpDemo.Chapters.Enumerations

open System
open System.ComponentModel
open MaxInno.Console.Menu
open MaxInno.Console.Utils
open MaxInno.Extensions.Enum

type DayOfWeek =
    | Monday = 1
    | Tuesday = 2
    | Wednesday = 3
    | Thursday = 4
    | Friday = 5
    | Saturday = 6
    | Sunday = 7
    
type DayOfWeekWithName =
    | [<Description("Понедiлок")>] Monday = 1
    | [<Description("Вiвторок")>]  Tuesday = 2
    | [<Description("Середа")>]    Wednesday = 3
    | [<Description("Четвер")>]    Thursday = 4
    | [<Description("П'ятниця")>]  Friday = 5
    | [<Description("Субота")>]    Saturday = 6
    | [<Description("Недiля")>]    Sunday = 7

let getMenu() =
    ConsoleMenu(
        title = "Робота з перелiченнями",
        entries = [
            {
                title = "Отримати константу дня тижня за номером"
                executor = fun() ->                    
                    let input = readUserInt32OrThrow("Введiть номер дня нижня")
                    if input < 1 || input > 7 then
                        raise (ArgumentException("номер для тижня має бути мiж 1 та 7"))
                    
                    let dayOfWeek: DayOfWeek = enum(input) 
                    printfn "\n Вибраний день тижня: %s" (dayOfWeek.ToString())
            }
            {
                title = "Отримати назву дня тижня за його номером"
                executor = fun() ->
                    let input = readUserInt32OrThrow("Введiть номер дня нижня")
                    if input < 1 || input > 7 then
                        raise (ArgumentException("номер для тижня має бути мiж 1 та 7"))
                        
                    let dayOfWeek: DayOfWeekWithName = enum(input)
                    let dayOfWeekString: string = dayOfWeek.toDescriptionString()
                    printfn "\n Вибраний день тижня: %s" dayOfWeekString
            }
        ],
        isSubMenu = true)