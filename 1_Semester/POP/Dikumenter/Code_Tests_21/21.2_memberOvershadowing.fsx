/// 21.2 memberOvershadowing.fsx
/// Inherited members can be overshadowed, but we can still access the base' member.

/// Derived classes can replace base class members by defining new members overshadow
/// the base' member. The base' members are still abailable using the "base" keyword.
/// Shown down-under:

// A counter has an internal state initialized at instantiation and
// is incremented in steps of 1.
type counter (init : int) =
    let mutable i = init
    member this.value with get () = i and set (v) = i <- v
    member this.inc () = i <- i + 1

// A counter2 is a counter which increments in steps of 2.
type counter2 (init : int) =
    inherit counter (init)
    member this.inc () = this.value <- this.value + 2
    member this.incByOne () = base.inc () // inc by 1 implemented in base

// Uses line 11
let c1 = counter (0) // A counter by 1 starting with 0
printf "c1: %d" c1.value

// Uses line 12 - 13
c1.inc() // inc by 1
printfn " %d" c1.value

// Uses line 17 (inherited from counter line 11)
let c2 = counter2 (1) // A counter by 2 starting with 1
printf "c2: %d" c2.value

// Uses line 18
c2.inc() // inc by 2
printf " %d" c2.value

// Uses line 13 and 19
c2.incByOne() // inc by 1
printfn " %d" c2.value


// In this case, we have defined two counters, each with an internal field i and with members
// value and inc. The inc method in counter increments i with 1, and in counter2 the field i
// is incremented with 2. Note how counter2 inherits both members value and inc, but overshadows
// inc by defining its own. Note also how counter2 defines another method incByOne by accessing
// the inherited inc method using the base keyword.