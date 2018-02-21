(*
   Exercise 6
   Christian S. Hansen, Daniel N. Krog and Michael K. Olesen
   Observe: We always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// E6g1                                                                // task
// XMLdoc header for float2frac:

/// <summary> The function float2frac returns the list used as input in cfloat2frac 
///    with the corresponding float number. </summary>
/// <remarks> The function checks for an empty list </remarks>
/// <param name="x"> The number (float) created from the function cfrac2float </param>
/// <returns> The list given as input in cfrac2float</returns>
/// <example> The following call <code> float2frac 3.245 </code>
///           will return <c> [3;4;12;4] </c> </example>

// val float2frac : x : float -> int list                           // signature
let rec float2frac (x : float) : int list =                         // definition

  if (abs(x) = abs(floor x) && abs(x-(floor x)) < 1.0E-10) then     // beginning of algorithm
    [int (floor x)]
  elif (abs(x-(floor x)) < 1.0E-10) then
    List.empty
  else
    // printfn "%A" x
    (int (floor x)) :: (float2frac (1.0/(x - (float(floor x)))))    // end of algorithm

// Blackbox testing
printfn "List from the float:  %f. Expected: %A. Actual: %A" (2.0) ([2]) (float2frac 2.0)                   // testing for point 0
printfn "List from the float:  %f. Expected: %A. Actual: %A" (3.245) ([3;4;12;4]) (float2frac 3.245)        // testing for a positive float number
printfn "List from the float: %f. Expected: %A. Actual: %A" (-3.245) ([-4;1;3;12;4]) (float2frac -3.245)    // testing for a negative float number. (It gives the wrong last number
                                                                                                            // because of a roundoff error somewhere in the calculation, If you
                                                                                                            // return the argument to normal instead of a comment in line 28
                                                                                                            // you can see that the last calculation should result in 4.
printf "\n" 

// Whitebox testing
printfn "List from the float:  %f. Expected: %A. Actual: %A" (0.0) ([2]) (float2frac 2.0)                   // testing lines 23-24
printfn "List from the float:  %f. Expected: %A. Actual: %A." (3.245) ([3;4;12;4]) (float2frac 3.245)       // testing lines 25-26-27-29
        // The last number in the resultning list is not the same, because
        // of af roundoff error. In the last calculation, it takes the float
        // 12.25000001 resulting in 3.999999840, where we use 'floor'
        // resulting in 3 (int), but it works correct with all of the
        // other numbers.
