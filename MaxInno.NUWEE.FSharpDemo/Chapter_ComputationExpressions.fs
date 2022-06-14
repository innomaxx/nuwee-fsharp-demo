
module MaxInno.FSharpDemo.Chapters.ComputationExpressions

open MaxInno.Console.Menu
open System.Net.Http
open System.IO

let getMenu() =
    ConsoleMenu(
        title = "Робота з обчислюваними виразами",
        entries = [
            {
                title = "Async"
                executor = fun() ->
                    let asyncExpr (url: string) =
                        async {
                            use client = new HttpClient() // new - disposable
                            let! response = client.GetStringAsync(url) |> Async.AwaitTask
                            do! File.WriteAllTextAsync("myip.txt", response) |> Async.AwaitTask
                        }
                        
                    let _ = asyncExpr "https://api.ipify.org/"
                    printfn "Async task gone"
            }
            {
                title = "Task"
                executor = fun() ->
                    let taskExpr (url: string) =
                        task {
                            use client = new HttpClient()
                            let! response = client.GetStringAsync(url)
                            do! File.WriteAllTextAsync("news.json", response)
                        }
                    
                    let _ = taskExpr "https://www.ukr.net/ajax/start.json"
                    printfn "Async task gone"
            }
        ],
        isSubMenu = true)