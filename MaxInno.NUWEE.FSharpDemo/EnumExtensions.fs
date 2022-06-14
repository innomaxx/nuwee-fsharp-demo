
module MaxInno.Extensions.Enum

open System.ComponentModel

type System.Enum with
    member this.toDescriptionString() =
        let atts = this
                      .GetType()
                      .GetField(this.ToString())
                      .GetCustomAttributes(typeof<DescriptionAttribute>, false)
        (atts[0] :?> DescriptionAttribute).Description