(*
   Task 6g
   Christian Sass Hansen, Daniel Nathan Krog
   and Michael Kwaensanthiah Olesen
   Observe: We always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// T6g0                                                                // task
// XMLdoc header for cfrac2float:

/// <summary> The function cfrac2float will return a float from a continued fraction
///    from a given list.
///    cfrac2float has the following signature: int list -> float </summary>
/// <remarks> The function checks for an empty list </remarks>
/// <param name="lst"> The list of numbers (int list) </param>
/// <returns> A resulting float from a continued fraction</returns>
/// <example> The following call <code> cfrac2float [3;4;12;4] </code>
///           will return <c> 3.245 </c> </example>

let rec cfrac2float (lst: int list) : float =                          // definition
  if List.isEmpty lst then                                             // beginning of algorithm
    0.0
  else if List.length lst = 1 then
      float (List.head lst)
  else  (float (List.head lst)) + 1.0/(cfrac2float (List.tail lst))    // end of algorithm
;;

// Blacbox testing
// (input, Expected output)
let testcases = [
    ([], 0.0);
    ([3], 3.0);
    ([3;4], 3.25);
    ([3;4;12], cfrac2float [3;4;12]);
    ([3;4;12;4], 3.245)
    ]

let test'float float_function x =
    float_function (fst x) = (snd x)

let test'print_results float_function (x: int list*float) =
    let res = test'float float_function x
    printfn "Input: %A.\nExpected %f. Actual: %f.\nComparison: %b.\n" (fst x) (snd x) (float_function (fst x)) res
    res

let test f = List.map (test'print_results f) testcases

let all_tests_passed (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let test_float = test cfrac2float |> all_tests_passed

printfn "All tests passed for cfrac2float: %b\n" test_float

// Whitebox testing
printfn "Testing lines: 23-24\nComparison: %b\n" (cfrac2float [] = 0.0)                   // Testing lines 23-24
printfn "Testing lines: 23-24-25-26\nComparison: %b\n" (cfrac2float [3] = 3.0)            // Testing lines 23-24-25-26
printfn "Testing lines: 23-24-25-26-27\nComparison: %b" (cfrac2float [3;4;12;4] = 3.245)  // Testing lines 23-24-25-26-27
