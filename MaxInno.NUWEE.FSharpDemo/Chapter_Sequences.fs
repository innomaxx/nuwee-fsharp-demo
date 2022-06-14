
module MaxInno.FSharpDemo.Chapters.Sequences

open MaxInno.Console.Menu
open MaxInno.Console.Utils

let getMenu() =
    ConsoleMenu(
        title = "Послiдовностi",
        entries = [
            {
                title = "Лiчилка чисел з кроком 1"
                executor = fun() ->
                    let numFrom = readUserInt32OrThrow("Введiть початкове число")
                    let numTo = readUserInt32OrThrow("Введiть кiнцеве число")
                    
                    let sequence = seq { numFrom .. numTo }
                    printf $"\n Послiдовнiсть: "
                    printEnumerable(sequence, 1)
            }
            {
                title = "Лiчилка чисел зi заданим кроком"
                executor = fun() ->
                    let numFrom = readUserInt32OrThrow("Введiть початкове число")
                    let numTo = readUserInt32OrThrow("Введiть кiнцеве число")
                    let step = readUserInt32OrThrow("Введiть крок")
                    
                    let sequence = seq { numFrom .. step .. numTo }
                    printf $"\n Послiдовнiсть: "
                    printEnumerable(sequence, 1)
            }
            {
                title = "Степiнь 2 та 3 для послiдовностi"
                executor = fun() ->
                    let numFrom = readUserInt32OrThrow("Введiть початкове число")
                    let numTo = readUserInt32OrThrow("Введiть кiнцеве число")
                    
                    let sequence = seq { for n in numFrom .. numTo do yield n, n*n, n*n*n }
                    printf $"\n Послiдовнiсть: "
                    printEnumerable(sequence, 1)
            }
            {
                title = "Вивести тiльки простi числа з послiдовностi"
                executor = fun() ->
                    let numFrom = readUserInt32OrThrow("Введiть початкове число")
                    let numTo = readUserInt32OrThrow("Введiть кiнцеве число")
                    
                    let isPrime(n: int) =
                        let rec check i =
                            i > n/2 || (n % i <> 0 && check(i + 1))
                        check 2
                        
                    let sequence = seq { for n in numFrom .. numTo do if isPrime n then yield n }
                    printf "\n Простi числа: "
                    printEnumerable(sequence, 1)
            }
        ],
        isSubMenu = true)