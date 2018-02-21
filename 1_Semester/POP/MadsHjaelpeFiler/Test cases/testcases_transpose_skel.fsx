// This is a skeleton/example file that mainly
// provides scaffolding for writing test cases

let transpose (xs : 'a list list) : 'a list list =
    // Fill in your code for transpose

// =============================================================================
// Now we want to run some tests!
// We can create a lot of different functions to help us
// Make a decision on WHAT you want to test and HOW.
// These are only suggestions on how to structure and execute tests.
// Remember: Printing is not testing.
// =============================================================================


// =============================================================================
// We create some testcases. We use tuples, where the first element is
// the matrix to transpose, and the second element is the expected result.
// This way, we can test by doing
// transpose (fst testcase) = (snd testcase)
// =============================================================================

// Test an empty matrix!
let te = ([[]],[])
// Test two 3x3 matrices
let t  = ([ [1;1;1] ; [2;2;2] ; [3;3;3] ], [ [1;2;3] ; [1;2;3] ; [1;2;3] ])
let t2 = ([ [1;2;3] ; [4;5;6] ; [7;8;9] ], [ [1;4;7] ; [2;5;8] ; [3;6;9] ])
// Add more testcases here


// And add all the testcases to the list
let testcases = [te;t;t2]


// You can run transpose on all the testcases,
// by mapping the function fst over testcases.
// testcases is a list of tuples, with type
// (int list list * int list list) list
List.map transpose (List.map fst testcases)

// Create a function that takes a testcase-tuple, and checks if the actual
// value is = expected value (return true if transpose returns the expected matrix)
let test'transpose x = transpose (fst x) = (snd x)
// You can test all your testcases, by mapping the function test'transpose
// over the list testcases.
List.map test'transpose testcases

// You can do the same without test'transpose, by using a lambda function
List.map (fun x -> transpose (fst x) = (snd x)) testcases

// You can even create a new function that prints the result of test'transpose
let test'transpose_print x =
    printfn "Test passed:%b" (test'transpose x)

// And then map that function over testcases to test and print
List.map test'transpose_print testcases


    
