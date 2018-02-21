// Listing 20.14 classOverloadOperator.fsx
// Operators can be overloaded using.

// All operators have a functional equivalence (+) and (^~ -) (unitary minus) 
// as static members. This is demostrated down-under:

type anInt (v : int) =
    member this.value = v
    static member (+) (v : anInt, w : anInt) = anInt (v.value + w.value)
    static member (~-) (v : anInt) = anInt (-v.value)

and aFloat (w : float) =
    member this.value = w
    static member (+) (v : aFloat, w : aFloat) = aFloat (v.value + w.value)
    static member (+) (v : anInt, w : aFloat) =
        aFloat ((float v.value) + w.value)
    static member (+) (w : aFloat, v : anInt) = v + w // Reuse def. above
    static member (~-) (v : aFloat) = aFloat (-v.value)

let a = anInt (2)                                        // Uses line 8
let b = anInt (3)                                        // Uses line 8
let c= aFloat (3.2)                                      // Uses line 13
let d = a + b // anInt + anInt                           // Uses line 9
let e = c + a // aFlaot + anInt                          // Uses line 17
let f = a + c // anInt + aFloat                          // Uses line 15 - 16
let g = -a // unitary - (minus) anInt                    // Uses line 10
let h = a + -b // anInt + unitary - (minus) anInt        // Uses line 9
printfn "a=%A, b=%A, c=%A, d=%A" a.value b.value c.value d.value
printfn "e=%A, f=%A, g=%A, h=%A" e.value f.value g.value h.value

// With the unitary minus, we are able to subtract objects of "anInt" by first negating
// the right-hand operand and then adding the result to the left-hand operand, thus
// demostrating the difference between unary and binary minus operators, where the
// binary minus would have been defined as - 
// "static member (-) (v : anInt, w : aFloat) = anInt ((float v.value) - w.value)".

// Beware that operator overloading outside class definitions overwrites all definitions
// of the operator. E.g., overloading (+) (v, w) outside a class will influence integer,
// real, string, etc. This, operator overloading should only be done inside class definitions.
