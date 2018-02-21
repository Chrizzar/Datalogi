/// 21.6 classInterface.fsx
/// Interfaces specifies which members classes contain, and with upcasting gives more
/// flexibility than abstract classes.

/// Inheritance of an abstract base class allows an application to rely on the definition
/// of the base regardless of any future derived classes. This is what interfaces offer.
/// An interface specifies which members must exist but nothing more.
/// Interfaces are defined as an abstract class without arguments and only with
/// abstract members. Classes implementing interfaces must specify implementations
/// for the abstract members using the interface with keywords. Objects of classes
/// implementing interfaces can be upcasted, as if they had an abstract base class 
/// of the interface’ name. Shown down-under:

// An interface for classes that have method fct and member value
type IValue =
    abstract member fct : float -> float
    abstract member value : int

// A house implements the IValue interface
type house (floors : int, baseArea : float) =
    interface IValue with
    // Calculate total price based on per area average
    member this.fct (pricePerArea : float) =
        pricePerArea * (float floors) * baseArea
    // Return number of floors
    member this.value = floors

// A person implements the IValue interface
type person(name : string, height : float, age : int) =
    interface IValue with
        // Calculate body mass index (kg/(m*m)) using hypothetic mass
        member this.fct (mass : float) = mass / (height * height)
        // Return the length of name
        member this.value = name.Length
    member this.data = (name, height, age)

let a = house(2, 70.0) // A two storage house with 70 m*m base area
let b = person("Donald", 1.8, 50) // A 50 year old person, which are 1.8 meter high
let lst = [a :> IValue; b :> IValue]
let printInterfacePart (o : IValue) =
    printfn "value = %d, fct(80.0) = %g" o.value (o.fct 80.0)
List.iter printInterfacePart lst


/// Here, two distinctly different classes are defined: house and person.
/// These are not related by inheritance, since no sensible common structure seems
/// available. However, they share structures in the sense that they both have an
/// integer property and a float -> float method. For each of the derived classes,
/// these members have different meaning. Still, some treatment of these members by
/// an application will only rely on their type and not their meaning. E.g., in
/// Listing 21.6 the printfn function only needs to know the member’s type not their
/// meaning. As a consequence, the application can upcast them both to the implicit
/// abstract base class IValue, put them in an array, and apply a function using the
/// member definition of IValue with the higher-order List.iter function.
/// Another example could be a higher order function calculating average values:
/// For average values of the number of floors and average value of the length of
/// people’s names, the higher order function would only need to know that both of
/// these classes implements the IValue interfaces in order to calculate the average
/// of list of either objects types.

/// As a final note, inheritance ties classes together in a class hierarchy.
/// Abstract members enforces inheritance and imposes constraints on the derived
/// classes. Like abstract classes, interfaces imposes constrains on derived classes,
/// but without requiring a hierarchical structure.