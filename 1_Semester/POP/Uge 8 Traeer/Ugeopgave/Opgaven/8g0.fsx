// Christian Sass Hansen
// Opgave 8g.0
// Last edited 02/11-2017

type weekday = Monday | Tuesday | Wednesday |Thursday | Friday | Saturday | Sunday

// Opgave 8g0
let numberToDay (a:int) =
    match a with
        | 1 -> Some Monday
        | 2 -> Some Tuesday
        | 3 -> Some Wednesday
        | 4 -> Some Thursday
        | 5 -> Some Friday
        | 6 -> Some Saturday
        | 7 -> Some Sunday
        | _ -> None
;;
printfn "numberToDay(1) = Monday = %b\n" (Some Monday = numberToDay 1)
