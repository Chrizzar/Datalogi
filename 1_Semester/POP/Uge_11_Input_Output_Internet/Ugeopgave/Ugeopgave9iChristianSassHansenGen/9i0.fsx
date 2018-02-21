/// Christian Sass Hansen
/// 9i0
/// Last edited: 29/11 - 2017


/// XMLdoc header for file safeIndexIf:

/// <summary> The function safeIndexIf will return a value as a integer in arr on place i, if i is a valid index, and else handling a error situation </summary>
/// <remarks> This function does not function with a empty list. It will just return an error <remarks>
/// <param name="arr"> The parameter "arr" is the array  ('a []) </param>
/// <param name="i"> The parameter "i" the index (int) </param>
/// <returns> It will return the value as a integer in arr on place i, if "i" is a valid index </returns>
/// <example> The following call: <code> safeIndexIf [|1; 2; 3; 4|] 2 </code>
/// This returns the integer 3 </example>

// 'a [] -> int -> 'a                                          // Signature
let safeIndexIf (arr : 'a []) (i : int): 'a =            // Definition
    Array.get arr i

printfn ""
printfn "*** safeIndexIf ***"

// Testing for index in range
printfn "Index in range:"
printfn "%i\n" (safeIndexIf [|1; 2; 3; 4|] 2)
// printfn "%i\n" (safeIndexIf [|1; 2|] 3)


/// XMLdoc header for file safeIndexTry:

/// <summary> The function safeIndexTry will return a value as a integer in arr on place i, if i is a valid index, and else handling a error situation </summary>
/// <remarks> safeIndexTry can take empty array <remarks>
/// <param name="arr"> The parameter "arr" is the array  ('a []) </param>
/// <param name="i"> The parameter "i" the index (int) </param>
/// <returns> It will return the value as a integer in arr on place i, if "i" is a valid index, and else handling a error situation </returns>
/// <example> The following call: <code> safeIndexTry [||] 2 </code>
/// This returns a error situation "ERROR: Your array is empty" </example>

// 'a [] -> int -> 'a                                          // Signature
let safeIndexTry (arr : 'a []) (i : int): 'a =           // Definition
     try
         if Array.isEmpty arr then
             failwith "ERROR: Your array is empty"

         else
             Array.get arr i
     with
         | :? System.IndexOutOfRangeException ->
             failwith "ERROR: The Index is out of range"

printfn "*** safeIndexTry ***"

// Testing for an empty array
printfn "An empty array:"
try safeIndexTry [||] 2 with
    | Failure msg -> printfn "%s\n" msg ; 2 ;;

// Testing for index out of range
printfn "Index out of range:"
try safeIndexTry [|1; 2; 3; 4|] 5 with
    | Failure msg -> printfn "%s\n" msg ; 5 ;;

// Testing for an array which have 4 element (calls for index 2):
printfn "Index in range:"
printfn "%i\n" (safeIndexTry [|1; 2; 3; 4|] 2)


/// XMLdoc header for file safeIndexTry:

/// <summary> The function safeIndexOption will return a value as a integer in arr on place i, if i is a valid index, and else handling a error situation </summary>
/// <remarks> Will only return as a Some or None <remarks>
/// <param name="arr"> The parameter "arr" is the array ('a []) </param>
/// <param name="i"> The parameter "i" the index (int) </param>
/// <returns> It will return the value as a integer in arr on place i, if "i" is a valid index, and else handling a error situation </returns>
/// <example> The following call: <code> safeIndexOption [|1; 2; 3; 4|] 5 </code>
/// This returns System.ArgumentException: The option value was None </example>

// 'a [] -> int -> 'a option                                                // Signature
let safeIndexOption (arr : 'a []) (i : int): 'a option =            // Defintion
    try
        if Array.isEmpty arr then
            failwith "ERROR: Your array is empty"

        else
            Some arr.[i]

    with
        | :? System.IndexOutOfRangeException -> None

printfn "*** safeIndexOption ***"
// Testing for an empty array
printfn "An empty array:"
try Option.get(safeIndexOption [||] 2) with
    | Failure msg -> printfn "%s\n" msg ; 2 ;;

// Testing for an array which have 4 element (calls for index 2):
printfn "Index in range:"
printfn "%A\n" (Option.get(safeIndexOption [|1; 2; 3; 4|] 2))

// Testing for index out of range
printfn "Index out of range:"
printfn "%A" (Option.get(safeIndexOption [|1; 2; 3; 4|] 5))
