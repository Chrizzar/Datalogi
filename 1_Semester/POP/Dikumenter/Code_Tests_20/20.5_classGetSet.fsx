// Listing 20.5 classGetSet.fsx
// Members can act as variables with the built-in getter and setter functions.

type aClass () =
    let mutable v = 0
    member this.value
        with get () = v
        and set (a) = v <- a

let a = aClass ()
printfn "%d" a.value
a.value <- 2
printfn "%d" a.value
a.value <- 3
printfn "%d" a.value

// The expression defining get: () -> 'a and set: 'a -> (), where 'a
// is any type, and can be any usual expression.

// The application calls the "get" and "set" as if the property were a
// mutable value. If "set" is omitted, the the property act as a value
// rather than a variable, and values cannot be assigned to it in the
// application program.