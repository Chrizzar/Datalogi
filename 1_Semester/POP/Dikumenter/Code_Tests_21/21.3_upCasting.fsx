/// 21.3 upCasting.fsx
/// Objects can be upCasted resulting in an object as if it were its base.
/// Implementations from the derived class are ignored.

/// Even though derived classes are different from their base, the derived class includes
/// the base class, which can be recalled using upcasting by the upcast operator “:>”.
/// At compile-time this operator removes the additions and overshadowing of the derived 
/// class, as illustrated in Listing 21.3.

// Hello holds property str
type hello () =
    member this.str = "hello"

// Howdy is a hello class and has property altStr
type howdy () =
    inherit hello ()
    member this.str = "howdy"
    member this.altStr = "hi"

let a = hello ()
let b = howdy ()
let c = b :> hello // A howdy object as if it were a hello object
printfn "%s %s %s %s" a.str b.str b.altStr c.str


/// Here howdy is derived from hello, overshadows str, and adds property altStr. 
/// By upcasting object b, we create object c as a copy of b with all its fields, 
/// functions, and members as if it had been of type hello. I.e., c contains the 
/// base class version of str and does not have property altStr. Objects a and c 
/// are now of same type and can be put into, e.g., an array as let arr = [|a, c|].
/// Previously upcasted objects can also be downcasted again using the downcast 
/// operator :?>, but the validity of the operation is checked at runtime. 
/// Thus, avoid downcasting when possible.