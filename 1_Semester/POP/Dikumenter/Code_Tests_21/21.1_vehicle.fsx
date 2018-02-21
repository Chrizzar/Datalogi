// 21.1 vehicle.fsx
// New classes can be deridved form old.

// Consider the concepts of a car and bicycle. They are both vehicles that can move 
// forward and turn, but a car can move in reverse, has 4 wheels uses gasoline or 
// electricity, while a bicycle has 2 wheels and needs to be pedalled. 
// Structurally we can say that “a car is a vehicle” and “a bicycle is a vehicle”.
// Such a relation is sometimes drawn as a tree as shown in Figure 21.1 and is called an
// is-a relation. Is-a relations can be implemented using class inheritance, where vehicle
// is called the base class and car and bicycle are each a derived class. 
// The advantage is that a derived class can inherent the members of the base class,
// override and add possibly new members. Inheritance is indicated using the "inherit"
// keyword. Listing 20.1 shows the syntax for class definitions using inheritance,
// and an example of defining base and derived classes for vehicles is shown down-under:

// A general vehicle, which moves on a plane and has a heading direction
type vehicle () =
    let mutable p = (0.0, 0.0) // Coordiante on a plane
    let mutable d = 0.0 // Heading direction in radians
    member this.dir with get() = d
    member this.pos with get() = p and set aPos = p <- aPos
    member this.turn angle = // turn heading direction
        d <- d + angle
    member this.foward step = // move forward (abs step)
        let s = abs step
        let vec = (s * (cos d), s * (sin d))
        p <- (fst p + fst vec, snd p + snd vec)

// A car is a vehicle, has wheels and can move in reverse
type car (name) =
    inherit vehicle () // Inherit dir, pos, turn, and forward
    member this.wheels = 4 // A car has 4 wheels
    member this.reverse step = // move backwards (abs step)
        let s = - abs step
        let vec = (s * (cos this.dir), s * (sin this.dir))
        this.pos <- (fst this.pos + fst vec, snd this.pos + snd vec)

// A bicycle is a vehicle and has wheels
type bicycle () =
    inherit vehicle () // Inherit dir, pos, turn, and forward
    member this.wheels = 2 // A Bike has 2 wheels

let aVehicle = vehicle () // Has dir, pos, turn, forward
let aCar = car () // Has dir, pos, turn, forward, wheels, reverse
let aBike = bicycle () // Has dir, pos, turn, forward, wheels
printfn "The car aCar has %d wheels" aCar.wheels
printfn "the bicycle aBike has %d wheels" aBike.wheels

// In the example, a base class vehicle is defined with members dir, pos, turn, and forward.
// The derived classes inherit all the members of the base class, but do not have access 
// to any non-members of the base’s constructor. I.e., car and bicycle automatically 
// have methods turn and forward, and properties dir and pos with their accessors, 
// but they do not have direct access to the fields p and d. 
// Both derived classes additionally define a property wheels and car also define a
// method reverse. Note that inheritance is one-way, and in spite that both derived classes
// define a member wheels, the base class does not have a wheels member.
// Derived classes can replace base class members by defining new members overshadowing
// the base’ member. The base’ members are still available using the base-keyword. 
// Consider the example in the next file 21.2_memberOvershadowing.fsx