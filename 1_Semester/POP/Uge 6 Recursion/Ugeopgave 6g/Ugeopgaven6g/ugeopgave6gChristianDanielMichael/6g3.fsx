(*
    Opgave 6g3
    Christian S. Hansen, Daniel N. Krog og Michael K. Olesen
*)

/// <summary> Converts a continued fraction into a rational number. </summary>
/// <remarks> Uses a helperfunction to hold a variable outside the scope of the inner function. </remarks>
/// <param name="lst"> Continued fraction as an array (int list). </param>
/// <param name="i"> Index (int) of the rational number ti/ni. </param>
/// <returns> Returns the rational number in the form of a tuple (int * int). </returns>
/// <example> The following <code>  cfrac2frac [3; 4; 12; 4] 1 </code> will return <c> (13, 4) </c> </example>

// val cfrac2frac lst: int list -> i: int -> int * int                                                                                                             // signature
let cfrac2frac (lst : int list) (i : int) : int * int =                                                                                                            // definition
  let orig_i = i
  
  if List.isEmpty lst || i < 0 || i > (List.length lst - 1) then                                                                                                   // beginning of algorithm
    (0, 0)

  else
    if (orig_i % 2 = 0) then
      let rec innerFunc (lst : int list) (i : int) : int * int = 
        if (i = -1 || i = -2) then
          (0, 1)
        else
          (List.item i lst * (snd(innerFunc lst (i-1))) + (fst(innerFunc lst (i-2))), List.item i lst * (fst(innerFunc lst (i-1))) + (snd(innerFunc lst (i-2)))) 
      innerFunc lst i

    else
      let rec innerFunc(lst : int list) (i : int) : int * int = 
        if (i = -1 || i = -2) then
          (1, 0)
        else
          (List.item i lst * (snd(innerFunc lst (i-1))) + (fst(innerFunc lst (i-2))), List.item i lst * (fst(innerFunc lst (i-1))) + (snd(innerFunc lst (i-2)))) 
      innerFunc lst i                                                                                                                                               // end of algorithm

// Whiteboxtest 
printfn "Calling cfrac2frac with [3; 4; 12; 4] 0. Expected: (3,1). Actual: %A" (cfrac2frac [3; 4; 12; 4] -1)       // testing line 17-18 
printfn "Calling cfrac2frac with [3; 4; 12; 4] 0. Expected: (3,1). Actual: %A" (cfrac2frac [3; 4; 12; 4] 0)        // testing line 21-27
printfn "Calling cfrac2frac with [3; 4; 12; 4] 1. Expected: (13,4) Actual: %A" (cfrac2frac [3; 4; 12; 4] 1)       // testing line 30-35

// Blackboxtest
printfn "Calling cfrac2frac with [3; 4; 12; 4] -1. Expected: (13,4). Actual: %A" (cfrac2frac [3; 4; 12; 4] 1)      // testing for negativ index 
printfn "Calling cfrac2frac with [3; 4; 12; 4] 4. Expected: (13,4). Actual: %A" (cfrac2frac [3; 4; 12; 4] 1)       // testing for index larger than list size
printfn "Calling cfrac2frac with [] 0. Expected: (0,0). Actual: %A" (cfrac2frac [] 0)                              // testing empty lists 
