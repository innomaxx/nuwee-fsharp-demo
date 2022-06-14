
module MaxInno.FSharpDemo.Chapters.TypeProviders

open MaxInno.Console.Menu
open FSharp.Data
open System

// samples, not json schema
type Person = JsonProvider<""" { "name":"Pedro", "age":94 } """>
type MixedTypes = JsonProvider<""" [1, 2, "hello", "world", true, false] """>
type People = JsonProvider<""" [ { "name":"Max", "age":22 }, { "name":"Ihor" } ] """>

let getMenu() =
    ConsoleMenu(
        title = "Робота з провайдерами типiв",
        entries = [
            {
                title = "JSON Provider"
                executor = fun() ->
                    let person = Person.Parse(""" { "name":"Tomas", "age":4 } """)
                    
                    printfn $" Iм'я: %s{person.Name}"
                    printfn $" Вiк: %i{person.Age}"
                    
                    let mixedTypes = MixedTypes.Parse(""" [4, 5, "hello", "world", true, true ] """)
                    printfn "\n Сума чисел: %i" (mixedTypes.Numbers |> Seq.sum)
                    
                    printfn " Стрiчки: %s" (mixedTypes.Strings |> String.concat(", "))
                    
                    printfn " Сума булевих значень: %i" (mixedTypes.Booleans
                                                    |> Seq.map(Convert.ToInt32)
                                                    |> Seq.sum)
                    
                    // People
                    printfn "\n Люди:"
                    for item in People.GetSamples() do
                        printf $" * %s{item.Name} "
                        
                        item.Age |> Option.iter (printf "(%d)")
                        printfn ""
            }
        ],
        isSubMenu = true)