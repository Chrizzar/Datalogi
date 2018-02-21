/// Christian Sass Hansen
/// 19.6 readKey
/// Last edited: 29/11 - 2017

open System

printfn "Start typing"
while true do
    let key = Console.ReadKey true
    let shift =
        if key.Modifiers = ConsoleModifiers.Shift then "SHIFT+" else ""
    let alt =
        if key.Modifiers = ConsoleModifiers.Alt then "ALT+" else ""
    let ctrl =
        if key.Modifiers = ConsoleModifiers.Control then "CTRL+" else ""
    printfn "You pressed: %s%s%s%s" shift alt ctrl (key.Key.ToString ())
