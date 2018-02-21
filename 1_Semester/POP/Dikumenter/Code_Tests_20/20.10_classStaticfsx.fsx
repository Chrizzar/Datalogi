// Listing 20.10 classStatic.fsx
// Static field and members are identical to all objects of the type.

type student (name : string) =

    // A static field "nextAvailableID" is created for the value to be shared
    // by all objects. The initialization of its value is only performed once,
    // at the beginning of program execution.
    static let mutable nextAvailableID = 0 // A global id for all objects

    // Every time an object is instantiated, then the value of "nextAvailableID"
    // is copied to the objectøs field "studentID" in line 13,
    // and "nextAvailableID" is updated.
    let studentID = nextAvailableID // A per object id
    do nextAvailableID <- nextAvailableID + 1
    member this.id with get () = studentID
    member this.name = name
    static member nextID = nextAvailableID // A global member

let a = student ("Jon") // Students will get unique ids, when instantiated
let b = student ("Hans")
printfn "%s: %d, %s: %d" a.name a.id b.name b.id
printfn "Next id: %d" student.nextID // Accessing the class's member