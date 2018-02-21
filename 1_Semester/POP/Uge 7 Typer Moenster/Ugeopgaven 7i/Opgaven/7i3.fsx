// Christian Sass Hansen
// Opgave 7i.3
// Last edited 01/11-2017

// Task: 7i.3
// XMLdoc header for lev:

/// <summary> The function lev, is a string metric for measuring the difference between two words with a minimum of one single character edits. Which is requried to change one word into the other. </summary>
/// <remark> The function checks for, if the length of the strings a and b is 0 (empty) <remarks>
/// <param name="a"> The character string a </param>
/// <param name="b"> The charecter string b </param>
/// <param name="i"> The length of a </param>
/// <param name="j"> The length of b </param>
/// <returns> Returns the difference in edits between two words </returns>
/// <example> The following call: <code>
/// a = "house"
/// b = "horse"
/// "lev[a,b](i,j) = %i" (lev a b (String.length a-1) (String.length b-1))
/// </code>
/// Will return 2 </example>

// val lev                                                        // signature
let rec lev (a:string) (b:string) (i:int) (j:int): int =        // definition
 //   let i = a.Length - 1
 //   let j = b.Length - 1
    if min i j = 0 then
        max i j
    else
        if a.[i] = b.[j] then
             min (lev a b (i-1) j + 1) (lev a b i (j-1) + 1)
             |> min (lev a b (i-1) (j-1) + 0)
        else
            min (lev a b (i-1) j + 1) (lev a b i (j-1) + 1)
            |> min (lev a b (i-1) (j-1) + 1)

let a = "house"

let b = "horse"

let a1 = "hi"

let b1 = "hej"

printfn "lev[a,b](i,j) = %i" (lev a b (String.length a-1) (String.length b-1))

printfn "lev[a,b](i,j) = %i" (lev a1 b1 (String.length a1-1) (String.length b1-1))
