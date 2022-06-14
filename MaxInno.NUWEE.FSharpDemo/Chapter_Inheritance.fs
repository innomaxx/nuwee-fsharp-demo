
module MaxInno.FSharpDemo.Chapters.Inheritance

open System
open MaxInno.Console.Menu
open MaxInno.Console.Utils

type IPerson =
    abstract name: string
    abstract age: int
    abstract sayHello: unit -> string

type Person(name: string, age: int, id: int) as self =
    member self.id = id
    
    member self.sayHello() =
        $"{name}, {age}: привiт!"
    
    interface IPerson with
        member this.name = name
        member this.age = age
        member this.sayHello() = self.sayHello()
            
type Student(name, age, id, university: string) =
    inherit Person(name, age, id)
    
    let mutable _salary: float32 = 0.0f
    
    member this.salary
        with get() = _salary
        and set value =
            if value < 0f then
                raise (ArgumentException("значення не може бути вiд'ємним"))
            else
                _salary <- value
                
    member this.university = university
    
    interface IPerson with
        member this.sayHello() =
            $"{base.sayHello()} Я студент!"
    
let getMenu() =
    ConsoleMenu(
        title = "Робота з наслiдуванням",
        entries = [
            {
                title = "Особа та Студент"
                executor = fun() ->
                    let name   = readRawUserInputOrThrow("Введiть iм'я")
                    let age    = readUserInt32OrThrow("Введiть вiк")
                    let id     = readUserInt32OrThrow("Введiть ID студента")
                    let univer = readRawUserInputOrThrow("Введiть установу")
                    let salary = readUserInt32OrThrow("Введiть суму виплат")
                    
                    let student = Student(name, age, id, univer)
                    student.salary <- float32 salary
                    printfn $"\n {(student :> IPerson).sayHello()}"
            }
        ],
        isSubMenu = true)