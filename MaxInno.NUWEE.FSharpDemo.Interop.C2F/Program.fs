
namespace MaxInno.NUWEE.FSharpDemo.Interop.C2F

module MainModule =
    [<EntryPoint>]
    let main _ =        
        let instance = CSharpToFSharp()
        printfn $"From F#: %s{instance.GetText_InstanceMethod()}"
        printfn $"From F#: %s{CSharpToFSharp.GetText_StaticMethod()}"
        0