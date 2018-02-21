// =============================================================================
// Matematik funktioner
// =============================================================================

let myName = "Mads"

printfn "%s" myName

// signature is int -> int
let double x = 2 * x

// Signature is float -> float
let doubleFloat x = 2.0 * x

// Evaluate the function call, to double the value 10 as int
double 10
// Evaluate the function call, to double the value 10.0 as float
doubleFloat 10.0

// Test the functions work!
let test'double x =
    let actual = (double x)
    let expected = 2 * x
    actual = expected


for i in [-10..10] do
    printfn "The function double works for %d: %b)" i (test'double i)

// signature is int -> int
let square x = x * x
// signature is float -> float
let squareFloat (x:float) = x * x

square 10 
squareFloat 12.0


// Calculate n!
let factorial n =
    let mutable sum = 1
    for i in 2..n do
        sum <- sum * i
// You can uncomment the next two lines, to see the values i and sum have during the looping
//        printfn "i: %d" i
//        printfn "sum: %d" sum
    sum


factorial 2
factorial 3
factorial 6
// This doesn't seem right? 
factorial 32
// This breaks at some point, when n is too large. Why? Let's write a test and find out when this happen!
    
for i in [1..20] do
    let f = factorial i
    // If the value of f < 0, we know we failed. n! is positive!
    if (f < 1) then
        printfn "Factorial failed at i = %d, giving the result %d" i f
    else
        printfn "factorial %d: %d" i f
        printfn "Factorial function works: %b" ( f > 0)




// Second degree polynomial: y = ax^2 + bx + c
// Using the squareFloat function from above
let polynomial2 a b c x = a * (squareFloat x) + b * x + c

// Create a function f of x, so we can get function values from a plynomial

let f(x) = polynomial2 3.0 2.0 0.0 x


for i in [-2.0..0.1..2.0] do
    // Print out the current function value at f(i)
    printfn "f(%f) = %.6f" i (f(i))








// =============================================================================
// string funktioner
// =============================================================================
// Signature is someone:string -> ()
let greetSomeone someone = sprintf "Hello, %s!" someone
printf "Greeting the great lizard king..."
greetSomeone "Jim Morrison"

// Funktioner med loops
// Signature is n:int -> ()
let printUpToNInOneLine n =
    for i in [1..n] do
        printf "%d " i
printfn "\n\nTesting printUpToNInOneLine with n = 10..."
printUpToNInOneLine 10

// Signature is n:int -> ()
let printUpToNInNLines n =
    for i in [1..n] do
        printfn "%d " i

printfn "\n\nTesting printUpToNInNLinesWhileLoop lines with n=10..."
printUpToNInNLines 10

// Signature is n:int -> ()
let printUpToNLinesWhileLoop n =
    let mutable i = 1
    while i <= n do
        printfn "%d " i
        // Increment i by 1
        i <- i + 1
//
printfn "\n\nTesting printUpToNLinesWhileLoop lines with n=10"
printUpToNLinesWhileLoop 10




