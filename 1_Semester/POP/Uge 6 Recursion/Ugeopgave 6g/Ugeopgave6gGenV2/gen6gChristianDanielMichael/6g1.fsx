(*
   Task 6g
   Christian Sass Hansen, Daniel Nathan Krog
   and Michael Kwaensanthiah Olesen
   Observe: We always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// T6g1                                                              // task
// XMLdoc header for float2cfrac:

/// <summary> The function float2cfrac returns the list used as input in cfloat2frac 
///    with the corresponding float number.
///    float2cfrac has the following signature: float -> int list </summary>
/// <remarks> The function checks for an empty list </remarks>
/// <param name="x"> The number (float) created from the function cfrac2float </param>
/// <returns> The corresponding list (int list) </returns>
/// <example> The following call <code> float2frac 3.245 </code>
///           will return <c> [3;4;12;4] </c> </example>

let rec float2cfrac (x : float) : int list =                        // definition

  if (abs(x) = abs(floor x) && abs(x-(floor x)) < 1.0E-10) then     // beginning of algorithm
    [int (floor x)]
  else if (abs(x-(floor x)) < 1.0E-10) then
    List.empty
  else if (abs(x-(ceil x))) < 1.0E-10 then
    (int (ceil x)) :: (float2cfrac (1.0/(x - (float(floor x)))))
  else
    (int (floor x)) :: (float2cfrac (1.0/(x - (float(floor x)))))   // end of algorithm

// Blackbox testing
// (Input, Expected output)
let testcases = [
    (3.245, [3;4;12;4]);
    ((1.0/0.245), float2cfrac (1.0/0.245));
    (12.25, [12;4]);
    (4.0, [4])
    ]

let test'float float_function x =
    float_function (fst x) = (snd x)

let test'print_results float_function (x: float * int list) =
    let res = test'float float_function x
    printfn "Input: %f.\nExpected %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (float_function (fst x)) res
    res

let test f = List.map (test'print_results f) testcases

let all_tests_passed (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let test_float = test float2cfrac |> all_tests_passed

printfn "All tests passed for float2cfrac: %b" test_float

// Whitebox testing
printfn "Testing lines: 22-23\nComparison: %b\n" (float2cfrac 3.0 = [3])              // testing lines 24-25
printfn "Testing lines: 22-23\nComparison: %b" (float2cfrac 3.245 = [3;4;12;4])       // testing lines 26-27-28-29-30-31
