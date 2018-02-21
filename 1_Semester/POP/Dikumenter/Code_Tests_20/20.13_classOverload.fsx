// Listing 20.13 classOverload.fsx
// Overloading methods set : int -> () and set : int * int -> () is permitted since
// they differ in argument number or type.

type Greetings () =
    let mutable greetings = "Hi"
    let mutable name = "Programmer"
    member this.str = greetings + " " + name
    member this.setName (newName : string) : unit =
        name <- newName
    member this.setName (newName : string, newGreetings : string) : unit =
        greetings <- newGreetings
        name <- newName

let a = Greetings () // Uses line 6, 7
printfn "%s" a.str
a.setName ("F# programmer") // Uses line 8, 9 - 10
printfn "%s" a.str
a.setName ("Expert", "Hello") // Uses line 8, 11 - 13
printfn "%s" a.str

// Overloading in class definition is allowed as long as the arguments differ
// in number or type.