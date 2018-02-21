// Create a string
let a = "Hello world"

// Create a new string, but using sprintf, and call it b
// a is our string, containing "Hello world"
// sprintf is a function. It takes (at least) two arguments as input
// 1. A format string
// 2. Values that are being used in the format string.
// Just like when printing, we can supply many arguments
let b = sprintf "%s" a
// b is now equal (=) to a

printfn "%s" b
// This will print true!
// The format string is "a = b: %b".
// The %b, means "replace this with a boolean value"
printfn "a = b: %b" (a = b)

// Let's print some numbers, using a format string
// %d means "insert an integer here. i is an integer.
for i in 0..10 do
    printfn "%d" i

// Let's print more values in one statement!
    // We'll print i with the first two % d.
    // The third %d, will be replaced with what the expression (i * i) evaluates to
    // (this will be i^2
    // The %b will be a boolean value. It's true if i is even, and false if i is odd
for i in 0..10 do
    printfn "%d * %d is %d. This is even: %b" i i (i * i) (i % 2 = 0)


// Make an empty, mutable string.
    // We need to make it mutable, so we can change it
let mutable s = ""
for i in 0..10 do
    // Take whatever s is, and add the string that (sprintf "%d" i) evaluates to, to the end.
    s <- s + sprintf "%d" i
    // Try printing out the result while looping through
    printfn "Now i am at i = %d. The string looks like\n%s" i s

printfn "%s" s



let mutable s2 = ""
for i in 99998..100005 do
    s2 <- s2 + sprintf "%5d\n" i
    printfn "Now i am at i = %d. The string looks like\n%s" i s2



// We can use padding to ensure a minimum width the things we insert in a format string should have

// Pad with up to 5 spaces 
printfn "%5d" 42

// Pad with up to 8 zeroes
// This is NOT proper binary. I'm using ints.
printf "0b%08d" 10

// Give me 16 decimals, please
printfn "%.16f" (22.0/7.0)

// Too much! I can do with only 3
printfn "%.3f" (22.0/7.0)
// But pad my number with spaces if it's less than 1000
// The 7 means "Make this at least 7 characters wide, padding with spaces
// The .3 means, give me 3 decimal places
// The .3 has precedence over the 7. The string is ensured to have 3 decimals, and if the string is then NOW wider than 7 characters, it will be padded.
// Basically, "make it seven wide, but make the decimals first". 7 - 3 is 4, but with the comma/dot, we will have 3 characters before the dot. 
printfn "%7.3f" (22.0/7.0)

// By padding with zeroes, this is easier to see
printfn "%07.3f" (22.0/7.0)
printfn "%08.3f" (22.0/7.0)
printfn "%09.3f" (22.0/7.0)



// return a string, with two lines, the first containing even numbers up to n
// The second containing odd numbers up to n
let evenNumbersFirst (n:int) =
    // Create two empty strings, to hold our numbers
    let mutable evenNumbers = ""
    let mutable oddNumbers = ""
    for i in 1..10 do
        if i % 2 = 0 then
            evenNumbers <- evenNumbers + sprintf "%5i" i
        else
            oddNumbers <- oddNumbers + sprintf "%5d" i
            // Return the two strings combined
    evenNumbers + "\n" + oddNumbers + "\n"

evenNumbersFirst 10

sprintf "%s" "hej"


// Returns a unit!
let printName name = printfn "Hello, %s!" name
// Returns a string! 
let getGreetingString name = sprintf "Hello, %s" name


let greeting = getGreetingString "Mads"
printfn "%s" greeting




let mutable mutableStringForLastExample
// This is a comparison. It means
// "is the string s equal to the string s + the string "1". This is clearly false.
mutableStringForLastExample = mutableStringForLastExample + "1"
// Assignment
// This means  "Take the value in mutableStringForLastExample, concatenate it with "1" and save the result in mutableStringForLastExample
mutableStringForLastExample <- mutableStringForLastExample + "1"






