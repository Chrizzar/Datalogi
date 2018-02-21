// Christian Sass Hansen
// Last edited 31/10-2017

type weekday = Monday | Tuesday | Wednesday |Thursday | Friday | Saturday | Sunday

// Opgave 8ø0
let dayToNumber weekday =
    match weekday with
        | Monday -> 1
        | Tuesday -> 2
        | Wednesday -> 3
        | Thursday -> 4
        | Friday -> 5
        | Saturday -> 6
        | Sunday -> 7

printfn "dayToNumber(Monday) = 1 = %b\n" (1 = dayToNumber Monday)


// Opgave 8ø1
let nextDay weekday =
    match weekday with
        | Monday -> Tuesday
        | Tuesday -> Wednesday
        | Wednesday -> Thursday
        | Thursday -> Friday
        | Friday -> Saturday
        | Saturday -> Sunday
        | Sunday -> Monday

printfn "nextDay(Monday) = %A = %b\n" (nextDay Monday) (Tuesday = nextDay Monday)
