
module MaxInno.Console.Utils

open System
open MaxInno.Extensions.String

let readRawUserInput(title: string) =
    Console.Write(" {0}: ", title)
    Console.ReadLine()
    
let readRawUserInputOrThrow(title: string) =
    let input: string = readRawUserInput(title)
    if String.IsNullOrWhiteSpace(input) then
        raise (ArgumentException("порожнiй рядок"))
    input
    
let readUserInt32OrThrow(title: string) =
    let input: string = readRawUserInputOrThrow(title)
    let mutable parsedNumber: int = 0
    if not <| Int32.TryParse(input, &parsedNumber) then
        raise (ArgumentException("ввiд не є цiлим числом"))
    parsedNumber
    
let readUserFloat32OrThrow(title: string) =
    let input: string = readRawUserInputOrThrow(title)
    let mutable parsedNumber: float32 = 0f
    if not <| Single.TryParse(input, &parsedNumber) then
        raise (ArgumentException("ввiд не є дробовим числом"))
    parsedNumber
    
let printEnumerable<'T>(enumerable: seq<'T>, width: int) =
    let join = String.Join(" | ", enumerable |> Seq.map(fun item -> item.ToString().wrapValue(width)))
    printfn $" | %s{join} |"