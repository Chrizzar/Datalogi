(*
|==========================================================================
| Example of cache and mutual recursion                                   |
| Calculate the nth fibonacci number                                      |
| This is a terrible way to calculate fibonacci numbers, and is solely    |
| chosen as an easily understandable example of mutual recursion          |
| and benefitting from a cache.                                           |
|                                                                         |
| "Calculations" are measured as recursive                                |
| calls to the fibonacci function                                         |
| fib sequence starts from 0 as 0, 1, 1, 2, 3, 5, 8, 13,....              |
|==========================================================================
*)

// Need this for pretty printing results
// Takes a digit, returns the proper digit string
// 1st, 2nd, 3rd, 4th, 5th etc.
let proper_digit_string n =
    match n with
        | 1 -> "1st"
        | 2 -> "2nd"
        | 3 -> "3rd"
        | _ -> sprintf "%dth" n

/// <summary>
/// Gets the nth fibonacci number.
/// Uncached, two recursive calls
/// </summary>
/// <remark>
/// Note that this function IS NOT recursive.
/// It wraps a recursive function.
/// </remark>
let fib (n:int):int =
    // Store calculations in a mutable
    let mutable calc = 0
    // Create an inner recursive function
    let rec inner_fib n =
        // Update calc value
        calc <- calc + 1
        match n with
            // First fib is 0
            | 0 -> 0
            // second fib is 1
            | 1 -> 1
            // fib_i is fib_i-2 + fib_i-1
            | _ -> inner_fib(n-2) + inner_fib(n-1)
    // Get result, so calculations is updated as a side effect
    let res = inner_fib n
    printfn "%s fibonacci number is: %d\nCalculations: %d" (proper_digit_string n) res calc
    // return result
    res






/// <summary>
/// Returns the nth fibonacci number
/// Cached. Stores calculated numbers to calculate them only once.
/// </summary>
/// <remark>
/// Note that this function IS NOT recursive.
/// It wraps two mutually recursive functions
/// </remark>
let cached_fib (n:int):int =
    // Store cache hits and number of calculations in mutables
    let mutable cache_hits = 0
    let mutable calc = 0
    // Create a cache
    // Here an array of ints (val cache : int [])
    // Here, the [] means array. A list would be int list
    // An array is mutable, so we can update values in the array.
    // Array.init takes an int, denoting the size of the array
    // And a function, that initializes all elements in the array
    // Here, we set all elements to -1
    let cache = Array.init (n+1) (fun x -> -1)

    // Now we need two mutually recursive functions, that can call each other
    // One will do lookups in the cache, the other will calculate fibs

    // Create an inner recursive function
    let rec cache_fib (n:int):int =
        // Check the value in the cache
        // If it's -1, we have not yet calculated that fib number
        match cache.[n] with
            | -1 ->
            // Not in cache, calculate
                calc <- calc + 1
                // Save the result from the calculation
                let res = inner_fib n
                // Save the result in the cache
                cache.[n] <- res
                // For debugging and seeing the cache every time it is updated
                // Uncomment following line
                // printfn "Cache:\n%A" cache
                // Return the result
                res
            | _ ->
                // If element in cache was not -1
                // it is a fib number.
                // Update cache_hits
                cache_hits <- cache_hits + 1
                // Get the fib number from cache and return it
                cache.[n]
    // Create a recursive function to calculate fibs
    // note that we write "and" instead of "let rec".
                // This makes the two recursive functions available to each other
    and inner_fib (n:int):int =
        match n with
            // fib_0 is 0
            | 0 -> 0
            // fib_1 is 1
            | 1 -> 1
            // fib_i is fib_i-2 + fib_i-1
            | _ ->
                // Calculate fib_i-2, using the cache
                let f2 = cache_fib(n-2)
                // Calculate fib_i-1, using the cache
                let f1 = cache_fib(n-1)
                // Return fib_i-2 + fib_i-1
                f2 + f1

    // Store the result in res
    let res = cache_fib n
    // Output cache hits and calculations
    printfn "%s fibonacci number is: %d" (proper_digit_string n) res
    printfn "Cache hits: %d" cache_hits
    printfn "Calculations: %d" calc

    // For debugging, uncomment following lines
    // To print the cache after calculations
    // printfn "Cache:\n%A" cache
    // Return the result
    res


let compare n =
    printfn "Calculate fib_%d using fib and cached_fib" n
    // Call fib, ignore result
    printfn "Using fib"
    fib n |> ignore
    // Call cached_fib, ignore result
    printfn "\nUsing cached_fib"
    cached_fib n |> ignore
    printfn ""
    ()

// Note that a new empty cache will be created on each call to cached_fib
// This mapping is only to show the calculations growing dramatically as n grows
// There are much better ways to get fibs in a list
// This will simply call compare for every n in a list

List.map compare [1..15]



// ==========================================================================
// Testing
// ==========================================================================
// Set up a list of tuples
// Each tuple contains (input,expected output)
let testcases = [
    (0, 0);
    (1, 1);
    (2, 1);
    (3, 2);
    (4, 3);
    (5, 5);
    (6, 8);
    (15, 610)
    (46, 1836311903)
    ]
// Take a fib function and an int as input
let test'fib fib_function x =
    // Call the fib function on the input from the test tuple
    // Compare it to the expected output from the test tuple
    fib_function (fst x) = (snd x)

let test'print_results fib_function (x:int*int) =
    let res = test'fib fib_function x
    printfn "test passed: %b" res
    res

// Test takes a function as input, either fib or cached_fib
// It gives that function as input to test'print_results
// This will evaluate to a function, waiting for an argument
// That function, is then mapped over all the testcases
// And a list of booleans is returned
let test f  = List.map (test'print_results f) testcases


// Getting a list of booleans is nice, but one boolean would be better
// Takes a list of booleans as input
// Uses fold to AND them all
// true && true = true
// false && true = false
let all_tests_passed (results: bool list) =
    // The commented line would do the same thing
    // List.fold (&&) true results
    List.fold (fun x acc -> x && acc) true results

// Run all tests for the fib function
// Pipe the result, a list of booleans
// to the function all_tests_passed
// all_tests_passed returns true if all tests are true,
// false otherwise
let test_fib'2 = test fib |> all_tests_passed
let test_cached_fib'2 = test cached_fib |> all_tests_passed

printfn "All tests passed for fib: \t\t%b" test_fib'2
printfn "All tests passed for cached_fib:\t%b" test_cached_fib'2
