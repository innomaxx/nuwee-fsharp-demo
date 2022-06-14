// See https://aka.ms/new-console-template for more information

using JetBrains.Annotations;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

using MaxInno.Console;

namespace MaxInno.NUWEE.FSharpDemo.Interop.C2F
{
    [PublicAPI]
    public class FSharpToCSharp
    {
        public FSharpToCSharp()
        {
            var menu = new Menu.ConsoleMenu
            {
                title = "Menu title",
                entries = ListModule.OfSeq(new[]
                {
                    new Menu.MenuEntry("title", FuncConvert.FromAction(() =>
                    {
                        System.Console.WriteLine("Hello world");
                    }))
                }),
                isSubMenu = true
            };
            
            menu.loop();
        }
    }
    
    [PublicAPI]
    public class CSharpToFSharp
    {
        public string GetText_InstanceMethod() => "Hello instance";

        public static string GetText_StaticMethod() => "Hello static";
    }

    public static class Program
    {
        public static void Main(string[] _)
        {
            System.Console.WriteLine("Hello from C#");
        }
    }
}