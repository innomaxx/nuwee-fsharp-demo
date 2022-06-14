
module MaxInno.Console.Menu

open System

type MenuEntry = {
    title: string
    executor: unit -> unit
}

type ConsoleMenu() =
    member val title: string = "Menu" with get, set
    member val entries: MenuEntry list = [] with get, set
    member val isSubMenu: bool = false with get, set
    
    member this.loop() =
        let mutable exitFromLoopFlag = false
        while not exitFromLoopFlag do
            Console.Clear()
            Console.WriteLine("\n [ {0} ]\n", this.title)
            
            let mutable counter = 0
            for menuEntry: MenuEntry in this.entries do
                this.addMenuEntry(&counter, menuEntry.title) |> ignore
            
            let exitMessage: string =
                if this.isSubMenu then "Повернутися до попереднього меню" else "Вихiд"
            let exitEntryId: int = this.addMenuEntry(ref counter, $"-- {exitMessage} --")
            
            Console.Write("\n Введiть ваш вибiр: ")
            let rawUserChoice: string = Console.ReadLine()
            
            let mutable parsedUserChoice: int = 0
            if (String.IsNullOrWhiteSpace(rawUserChoice) || not <| Int32.TryParse(rawUserChoice, &parsedUserChoice)) then
                Console.WriteLine(" Неправильний ввiд. Повторiть спробу")
                Console.ReadLine() |> ignore
                
            elif (parsedUserChoice > this.entries.Length + 1) then
                printfn " Неправильний порядковий номер пункту меню"
                Console.ReadLine() |> ignore
                
            elif (parsedUserChoice = exitEntryId) then                
                printf " Вихiд з програми"
                exitFromLoopFlag <- true
                
            else
                let entry: MenuEntry = this.entries[parsedUserChoice - 1]
                Console.Clear()
                Console.WriteLine("\n [ {0} ]\n", entry.title)
                
                try
                    entry.executor()
                with
                    | :? ArgumentException as ex -> Console.WriteLine("\n Помилка вводу: {0}", ex.Message)
                    | _ as ex -> Console.WriteLine("\n Помилка: {0}", ex.Message)
                    
                Console.WriteLine("\n Програма закiнчила виконання")
                Console.WriteLine(" Натиснiть Enter для повернення до меню")
                Console.ReadLine() |> ignore
                
    member private this.addMenuEntry(id: byref<int>, title: string): int =
        id <- id + 1
        Console.WriteLine(" {0}) {1}", id, title)
        id