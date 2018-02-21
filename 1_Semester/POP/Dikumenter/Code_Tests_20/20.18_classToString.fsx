// Listing 20.18 classToString.fsx
// Overriding ToString() function for better interaction with members of the printf
// family of prcedures. Compare with file 20.17_classPrintf.fsx

// All classes are given default member through a process called "inheritance", which will
// be shown in the 21.1 tests.
// When an object is given as argument to a "printf" function, then "printf" calls the
// object, as can be seen in above tests. But we may "override" this member using the
// "override" keyword as demostrated down-under:

type vectorWToString (x : float, y : float) =
    member this.x = (x,y)
    // Custom printing of objects by overriding this.ToString()
    override this.ToString() =
        sprintf "(%A, %A)" (fst this.x) (snd this.x)

let v = vectorWToString(1.0, 2.0)
printfn "%A" v // No change in application but result is better

// Beware, an application program may require other formatting choices then selected
// at the time of designing the class, e.g., in our example the application program may
// prefer square brackets as delimiters for vector tuples.
// So in general when designing an override to "ToString()" choose simple, generic formatting
// for the widest possible use.

// [<EXTRA>]
// The most generic formatting is not always obvious, and in the vecotr case some candidates
// for the formatting string of ToString() are "%A %A", "%A, %A", "(%A, %A)", or "[%A, %A]".
// A common choice is to let the formatting be controlled by static members that can be changed
// by the application program by accessors.