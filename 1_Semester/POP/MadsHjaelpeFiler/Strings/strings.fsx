// This is a string
let a = "abc"
// And another
let b = "123"
// Let's add the together
let ab = a + b
// Create a similar string in another way.
let c = "abc123"
//
let d = "abc" + "123"

// Now let's compare the values

printfn "ab = a + b: %b" (ab = a + b)
printfn "ab = c: %b" (ab = c)
printfn "ab = d: %b" (ab = d)
printfn "c  = d: %b" (c = d)


// Let's make a multiline string ending with a newline
let multilineFromOneStringWithNewlines = "Line 1 is this one\nLine 2 is this one\nLine 3 is this one\n"


// This is one string, but by adding \ to the end of the lines, we can write a
// string over multiple lines
let multilineFromOneStringVisualNewlines =
    "Line 1 is this one\n\
    Line 2 is this one\n\
    Line 3 is this one\n\
"

let multilineFromManyStringsWithNewLine =
    "Line 1 is this one\n" +
    "Line 2 is this one\n" +
    "Line 3 is this one\n"
    
multilineFromOneStringWithNewlines = multilineFromOneStringVisualNewlines
multilineFromOneStringWithNewlines = multilineFromManyStringsWithNewLine
multilineFromOneStringWithNewlines = multilineFromOneStringVisualNewlines


// Grab the first n lines
// of the string a, remembering the newline!
// We need to calculate how to get the newline

let firstLine = multilineFromManyStringsWithNewLine.[0..18]

// This is a function, taking an n (integer)
let myfun n =
    // Create a string bound to a, with the following contents
    let a =
        "DIKU 2017 PoP  DMA  \n" +
        "2017 PoP  DMA  DIKU \n" +
        "PoP  DMA  DIKU 2017 \n"
    printfn "The string a is %d long."  (String.length a)
//    let myBoundary = ???? // Here you need to calculate the last indice of the string
    // This should be returned
    //a.[0..myBoundary]
    // Instead for the example to compile, just return a.
    a



// Finding lengths of a string
// I use triple quotes to designate the string. that way i can use
// Single quotes inside the string. Cool!
printfn """Length of the string "abcd" is: %d""" (String.length "abcd")

// How long is this one? 
let myString = "\n"
printfn "Length of the string stored in myString (%A) is: %d" myString (String.length myString)
// And this one? 
let myString2 = "\n\n\n\n"
printfn "Length of the string stored in myString (%A) is: %d" myString2 (String.length myString2)

