// Listing 20.15 classExtraConstructor
// Exta constructors can be added using "new".

// Like methods, constructors can also be overloaded using the "new" keyword.
// E.g., the example 20.13 classOverload.fsx may be modified, such that the name and possibly
// greeting is set at object instantiation rather than by using the accessor.
// This is illustrated down-under:

// primary constructor
type classExtraConstructor (name : string, greetings : string) =
    static let defaultGreetings = "Hello"
    // Additional constructor are defined by: new ()
    new (name : string) =
        classExtraConstructor (name, defaultGreetings)
    member this.name = name
    member this.str = greetings + " " + name

let s = classExtraConstructor ("F#") // Calling additional constructor
let t = classExtraConstructor ("F#", "Hi") // Calling primary constructor
printfn "%A %A" s.str t.str 

// Before the call to the primary constructor, "let" and "do" statements are allowed.
// If code is is to be executed after the primary constructor has been called,
// then it must be preceded by the "then" keyword as shown in the next file:
// 20.16_classDoThen.fsx