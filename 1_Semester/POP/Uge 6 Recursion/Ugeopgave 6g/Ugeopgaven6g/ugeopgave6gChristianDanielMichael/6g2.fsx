(*
    Opgave 62g
    Christian S. Hansen, Daniel N. Krog og Michael K. Olesen
*)

/// <summary> Converts a fraction into its representation as continued fraction. </summary>
/// <param name="t"> Numerator of the fraction t/n (int). </param>
/// <param name="n"> Denominator of the fraction t/n (int). </param>
/// <returns> Returns a continued fraction as an array (int list). </returns>
/// <example> The following <code>  frac2cfrac 649 200</code> will return <c> [3;4;12;4] </c> </example>

// val frac2cfrac : t : int -> n : int -> int list                                                             // signature
let rec frac2cfrac (t : int) (n : int) : int list =                                                            // definition 

  if n = 0 then                                                                                                // beginning of algorithm
    List.empty
  else
    (int (t/n)) :: frac2cfrac n (t % n)                                                                        // end of algorithm

// Whiteboxtest
// Because frac2cfrac is recursive, it will always go into the if branch at least once, since its the stopping block,
printfn "Calling frac2cfrac with (649 200). Expected: [3;4;12;4]. Actual: %A" (frac2cfrac 649 200)             // testing line 15-18

// Blackboxtest
printfn "Calling frac2cfrac with (-649 200). Expected: [-3;-4;-12;-4]. Actual: %A" (frac2cfrac -649 200)       // testing for negative numerator/denominator, since -t/n = t/-n
printfn "Calling frac2cfrac with (649 200). Expected: [3;4;12;4]. Actual: %A" (frac2cfrac 649 200)             // testing for positive numerator/denominator
printfn "Calling frac2cfrac with (-649 -200). Expected: [3;4;12;4]. Actual: %A" (frac2cfrac -649 -200)         // testing for negative fraction
printfn "Calling frac2cfrac with (0 0). Expected: []. Actual: %A" (frac2cfrac 0 0)                             // testing for 0 
