(*
   Task 6g
   Christian Sass Hansen, Daniel Nathan Krog
   and Michael Kwaensanthiah Olesen
   Observe: We always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// T6g2                                                          // task
// XMLdoc header for frac2cfrac:

/// <summary> The function frac2cfrac returns a list from the
///    corresponding fractal as a tuple. frac2cfrac uses the following signature:
///    frac2cfrac: int -> int -> int list </summary>
/// <param name="t"> The numerator in a fractal </param>
/// <param name="t"> The The denominator in the same fractal </param>
/// <returns> A list which corresponds to the integer fractal </returns>
/// <example> The following call <code> frac2cfrac 649 200 </code>
///           will return <c> [3;4;12;4] </c> </example>

// val frac2cfrac : t : int -> n : int -> int list               // signature
let rec frac2cfrac (t : int) (n : int) : int list =              // definition

  if n = 0 then                                                  // beginning of algorithm
    List.empty
  else
    (int (t/n)) :: frac2cfrac n (t % n)                          // end of algorithm
;;
// Blackbox testing
// args1-4 = input
// (input, Expected output)
let args1 = (649, 200)
let args2 = (200, 49)
let args3 = (49, 4)
let args4 = (4, 1)
let testcase = [
    (args1, [3;4;12;4]);
    (args2, [4;12;4]);
    (args3, [12;4]);
    (args4, [4])
    ]

let third (_,_,c) = c

let test'float float_function x =
    float_function (fst (fst x)) (snd (fst x)) = (snd x)

let test'print_results float_function (x: (int*int) * int list) =
    let res = test'float float_function x
    printfn "Input: %A.\nExpected %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (float_function (fst (fst x)) (snd (fst x))) res
    res

let test f = List.map (test'print_results f) testcase

let all_tests_passed (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let test_float = test frac2cfrac |> all_tests_passed

printfn "All tests passed for frac2cfrac: %b\n" test_float

// Whitebox testing
printfn "Testing lines: 24-25\nComparison: %b\n" (frac2cfrac 200 0 = [])                 // Testing lines 24-25
printfn "Testing lines: 24-25-26-27\nComparison: %b" (frac2cfrac 649 200 = [3;4;12;4])   // Testing lines 24-25-26-27
