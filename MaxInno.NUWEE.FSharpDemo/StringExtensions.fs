
module MaxInno.Extensions.String

open System
open System.Collections.Generic

type String with
    member this.repeat(count: int) =
        let list = List<string>()
        for i = 0 to count do list.Add(this)
        String.Join("", list)
        
    member this.wrapValue(width: int) =
        let difference: int = width - this.Length
        let spaces = " ".repeat(difference)
        $"{spaces}{this}"