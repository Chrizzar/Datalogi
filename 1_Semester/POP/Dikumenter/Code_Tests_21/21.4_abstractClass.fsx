/// 21.4 abstractClass.fsx
/// In contrast to regular objects, upcasted derived object use the derived 
/// implementation of abstract methods.

/// An abstract class contains members defined using the "abstract member" and optionally
/// the "default" keywords. An abstract member in the base class is a type of definition,
/// and derived classes must provide an implementation using the "override" keyword.
/// Optionally, the base class may provide a default implementation using the "default"
/// keyword, in which case overriding is not required in derived classes.
/// Objects if classes containing abstract members without default implementation cannot
/// be instantiated, but derived classes that provide the missing implementations can be.
/// Note that abstact classes must be given the [<AbstractClass>] attribute.
/// Note also that in constrast to overshadowing, upcasting keeps the implementations
/// of the derived classes. Shown down-under:

// An abstract class for general greeting classes with property str
[<AbstractClass>]
type greeting () =
    abstract member str : string

// Hello is a greeting
type hello () =
    inherit greeting ()
    override this.str = "hello"

// Howdy is a greeting
type howdy () =
    inherit greeting ()
    override this.str = "howdy"

let a = hello ()
let b = howdy ()
let c = [| a :> greeting; b :> greeting |] // arrays of greetings

Array.iter (fun (elm : greeting) -> printfn "%s" elm.str) c


/// In the example, we define a base class and two derived classes. Note how the 
/// abstract member is defined in the base class using the “:”-operator as a type
/// declaration rather than a name binding. Note also that since the base class does
/// not provide a default implementation, the derived classes supply an implementation
/// using the override-keyword. In the example, objects of baseClass cannot be created,
/// since such objects would have no implementation for this.hello. Finally, the two
/// different derived and upcasted objects can be put in the same array, and when
/// calling their implementation of this.hello we still get the derived
/// implementations, which is in contrast to overshadowing.