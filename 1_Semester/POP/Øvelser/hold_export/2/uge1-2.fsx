// By Emil 'Dota' Bak, DIKU 2017
// Week 1 + 2 intro


// ----- Variables (non-mutable) and types ----- \\
let myInt = 5  // int
let myNewInt = 4 + myInt
    // myNewInt = 9
let myFloat = 4.7 // float
let myString = "Hello" // string
let myChar = 'a' // char


// ------------------ Lists -------------------- \\
let twoToSeven = [2;3;4;5;6;7] // an int list
let oneToSeven = 1 :: twoToSeven // concats an element into a new list
    // oneToSeven = [1;2;3;4;5;6;7]
let zeroToSeven = [0;1] @ twoToSeven // contats two lists
    // zeroToSeven = [0;1;2;3;4;5;6;7]


// ------------------ Printing -------------------- \\
printfn "Hello World" // Prints the given string, and a newline (due to the 'n' in printf)
printf "No newline here" // Prints the given string, but without a newline
printf ", But here is a manual newline: \n" // prints the string, which contains a newline '\n'

printfn "prints an integer: %i" myInt // The %i is where the given integer variable appears
printfn "prints a float: %f" myFloat // Same but with a float. Note how the variable name comes after
printfn "prints a string: %s World!" myString // Note how we can put '%s' in front with no trouble

// *** Quick print formatting table ***
// %i for ints
// %f for floats
// %s for strings
// %b for bools
// %A for pretty-printing tuples (aka 'Anything')


// ------------------ Functions ------------------- \\
let square x =
    x * x
    // takes in a number (int or float), and times it by itself, and returns it

printfn "callin function square with %i, it equals: %i" (myInt) (square myInt)



// ------------------ Recursive Functions ------------------- \\
// Recursive sum of ints in a list (listSum)
let rec listSum aList =
    match aList with
    | []      -> 0
    | (x::xs) -> x + (listSum xs)







