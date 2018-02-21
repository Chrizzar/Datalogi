// Christian Sass Hansen
// Opgave 7i.4
// Last edited 01/11-2017

// Task: 7i.4
// XMLdoc header for leven_cached, leven_cache, leven:

/// <summary> The function leven_cached will with two inner mutually recursive functions leven_cache and leven, return the difference in edits between two words.
/// As well as how many times we hit a calculation we already have calculated, and how many calculations it took to calculate the result. </summary>
/// <remark> This function is not recursive.
/// It wraps two recursive functions. <remarks>
/// <param name="a"> The character string a </param>
/// <param name="b"> The charecter string b </param>
/// <param name="i"> The length of a </param>
/// <param name="j"> The length of b </param>
/// <returns> It returns the difference in edits between two words.
/// As well as how many times we hit a calculation we already have calculated, and how many calculations it took to calculate the result. </returns>
/// <example> This following call: <code>
/// let a = "house"
/// let b = "horse"
/// "Result: %i\n" (leven_cashed a2 b2 (String.length a2-1) (String.length b2-1))
/// </code>
/// Returns:
/// Result: 1
/// Cache hits: 24
/// Calculations 24
/// Result: 1
/// </example>

// val leven_cached                                                                            // Signature
let leven_cashed (a:string) (b:string) (i:int) (j:int): int =                            // Definition
    let mutable cache_hits = 0
    let mutable calc = 0

    let cache = Array.init (a.Length) (fun x -> Array.init (b.Length) (fun x -> -1))

    /// <summary> The inner mutually recursive functions leven_cache and leven, can call each other.
    /// Leven_cache will do lookups in the cache, by checking if we don't have "that" calculation, it will insert it in the cache, so we don't have to do it again.
    /// And if we already have a calculation in the cache, we will get a cache hit, and therefore the program don't have to calculate it again. </summary>
    /// <remark> In the function leven_cache, where we inserts a calculation in the cache, we call the other recursive function leven, which we use for the calculation work.
    /// (We make the two mutually recursive functions, so they can call each other). <remarks>
    /// <param name="a"> The character string a </param>
    /// <param name="b"> The charecter string b </param>
    /// <param name="i"> The length of a </param>
    /// <param name="j"> The length of b </param>
    let rec leven_cache (a:string) (b:string) (i:int) (j:int): int =
        match cache.[i].[j] with
            | -1 ->
                // Not in the cache, calculation
                calc <- calc + 1
                // Saves the result from the calculation, which took place in the function "leven"
                let res = leven a b i j
                // Inserts a calculation in the cache, which doesn't already exist in the cache
                cache.[i].[j] <- res

                res
            | _ ->
                // Updating cache hits
                cache_hits <- cache_hits + 1
                // Numbers which are calculated
                cache.[i].[j]

    /// <summary> The function leven, will calculate the difference between two words with a minimum of one single character edits. </summary>
    /// <remark> We make the two mutually recursive functions, so they can call each other. <remarks>
    /// <param name="a"> The character string a </param>
    /// <param name="b"> The charecter string b </param>
    /// <param name="i"> The length of a </param>
    /// <param name="j"> The length of b </param>
    and leven (a:string) (b:string) (i:int) (j:int): int =
         if min i j = 0 then
             max i j
         else
             if a.[i] = b.[j] then
                 min (leven_cache a b (i-1) j + 1) (leven_cache a b i (j-1) + 1)
                 |> min (leven_cache a b (i-1) (j-1) + 0)
             else
                 min (leven_cache a b (i-1) j + 1) (leven_cache a b i (j-1) + 1)
                 |> min (leven_cache a b (i-1) (j-1) + 1)

    let res = leven_cache a b i j
    printfn "Result: %i" res             // Distance
    printfn "Cache hits: %i" cache_hits  // Cache hits
    printfn "Calculations: %d" calc      // Calculations

    res // Distance

let a = "house"
let b = "horse"
let a1 = "hi"
let b1 = "hej"
let a2 = "dangerous house"
let b2 = "danger horse"

printfn "Result: %i\n" (leven_cashed a b (String.length a-1) (String.length b-1))
printfn "Result: %i\n" (leven_cashed a1 b1 (String.length a1-1) (String.length b1-1))
printfn "Result: %i\n" (leven_cashed a2 b2 (String.length a2-1) (String.length b2-1))
