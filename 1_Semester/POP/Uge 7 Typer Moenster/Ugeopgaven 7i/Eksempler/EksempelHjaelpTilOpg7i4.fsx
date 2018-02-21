let rec even x =
    match x with
        | 0 ->
            printfn "original x is even!"
            true
        | _ ->
            printfn "printing x from even: %d" x
            odd (x-1)
and odd x =
    match x with
    | 0 -> false
    | _ ->
        printfn "Printing x from odd: %d" x
        even (x-1)

odd 3
even 4

List.filter odd [1..10]
