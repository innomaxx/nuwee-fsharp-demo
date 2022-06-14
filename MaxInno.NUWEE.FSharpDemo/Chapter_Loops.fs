
module MaxInno.FSharpDemo.Chapters.Loops

open System
open MaxInno.Console.Menu
open MaxInno.Console.Utils

let getMenu() =
    ConsoleMenu(
        title = "Цикли: види та застосування",
        entries = [
            {
                title = "for..to на прикладi чисел"
                executor = fun() ->
                    let limitFrom: int = readUserInt32OrThrow("Число вiд")
                    let limitTo: int = readUserInt32OrThrow("Число до")
                    
                    if limitFrom >= limitTo then
                        raise (ArgumentException($"{limitFrom} бiльше або дорiвнює {limitTo}"))
                    
                    printfn " "
                    for i = limitFrom to limitTo do printf $" %i{i}"
                    printfn ""
            }
            {
                title = "for..downto на прикладi чисел"
                executor = fun() ->
                    let limitFrom: int = readUserInt32OrThrow("Число вiд")
                    let limitTo: int = readUserInt32OrThrow("Число до")
                    
                    if limitFrom <= limitTo then
                        raise (ArgumentException($"{limitFrom} менше або дорiвнює {limitTo}"))
                    
                    printfn " "
                    for i = limitFrom downto limitTo do printf $" %i{i}"
                    printfn ""
            }
            {
                title = "for..in на прикладi квадратiв чисел"
                executor = fun() ->
                    let input = readRawUserInputOrThrow("Введiть числа")
                    let numbers = input
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries ||| StringSplitOptions.TrimEntries)
                                      |> Seq.map(Int32.Parse)
                    for number in numbers do
                        printf $" | {pown number 2}"
                    printfn " |"
            }
            {
                title = "while..do на прикладi збiльшення числа до порогу"
                executor = fun() ->
                    let initNumber = readUserInt32OrThrow("Введiть початкове число")
                    let limit = readUserInt32OrThrow("Введiть порiг")
                    let step = readUserInt32OrThrow("Введiть крок")
                    
                    let mutable workNumber = initNumber
                    printf $"\n | {workNumber}"
                    while workNumber < limit do
                        workNumber <- workNumber + step
                        printf $" -> {workNumber}"
                    printfn " |"
            }
        ],
        isSubMenu = true)