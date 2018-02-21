(*
   Exercise 6
   Christian S. Hansen, Daniel N. Krog and Michael K. Olesen
   Observe: We always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// E6g0                                                                // task
// XMLdoc header for cfrac2float:

/// <summary> The function cfrac2float will return a float from a continued fraction
///    from a given list. </summary>
/// <remarks> The function checks for an empty list </remarks>
/// <param name="lst"> The list of numbers (int list) </param>
/// <returns> A resulting float from a continued fraction</returns>
/// <example> The following call <code> cfrac2float [3;4;12;4] </code>
///           will return <c> 3.245 </c> </example>


// val cfrac2float : lst : int lst -> float                            // signature
let rec cfrac2float (lst: int list) : float =                          // definition
  if List.isEmpty lst then                                             // beginning of algorithm
    0.0
  else  (float (List.head lst)) + 1.0/(cfrac2float (List.tail lst))    // end of algorithm

// Blackbox testing
printfn "Float from the list: %A. Expected: %5f. Actual: %5f" ([]) (0.0) (cfrac2float [])                      // Testing for emptyness 
printfn "Float from the list: %A. Expected: %5f. Actual: %5f" ([3;4]) (3.0) (cfrac2float [3;4])                // Testing for 2 elements
printfn "Float from the list: %A. Expected: %5f. Actual: %5f" ([3;4;12]) (3.25) (cfrac2float [3;4;12])         // Testing for 3 elements
printfn "Float from the list: %A. Expected: %5f. Actual: %5f" ([3;4;12;4]) (3.245) (cfrac2float [3;4;12;4])    // Testing for 4 elements (The computer makes a roundoff error with the result, but it should be the correct answer)"
printf "\n"
// Whitebox testing
printfn "Float from the list: %A. Expected: %5f. Actual: %5f" ([]) (0.0) (cfrac2float [])                      // Testing lines 23-24
printfn "Float from the list: %A. Expected: %5f. Actual: %5f" ([3;4;12;4]) (3.245) (cfrac2float [3;4;12;4]   ) // Testing line 25
