/// 21.5 abstractDefaultClass.fsx
/// Default implementations in abstract classes makes implementations in derived
/// classes optional. Compare with file 21.4_abstractClass.fsx

/// Abstract classes may also specify a default implementation, such that derived
/// classes have the option of implementing an overriding member, but are not forced to.
/// In spite that implementations are available in the abstract class, the abstract
/// class still cannot be used to instantiate objects. Such a variant is shown down-under:

// An abstract class for general greeting classes with property str
[<AbstractClass>]
type greeting () =
    abstract member str : string
    default this.str = "hello" // Provide default implementation

// Hello is a greeting
type hello () =
    inherit greeting ()

// Howdy is a greeting
type howdy () =
    inherit greeting ()
    override this.str = "howdy"

let a = hello ()
let b = howdy ()
let c = [| a :> greeting; b :> greeting |] // Arrays of greetings
Array.iter (fun (elm : greeting) -> printfn "%s" elm.str) c


/// In the example, the program in Listing 21.4 has been modified such that greeting
/// is given a default implementation for str, in which case, hello does not need to
/// supply one. However, in order for howdy to provide a different greeting, it 
/// still needs provide an override member.

/// Note that even if all abstract members in an abstract class has defaults,
/// objects of its type can still not be created, but must be derived as, e.g.,
/// shown with hello above.

/// As a side note, every class implicitly derives from a base class System.Object
/// which, which is an abstract class defining among other members the ToString 
/// method with default implementation.