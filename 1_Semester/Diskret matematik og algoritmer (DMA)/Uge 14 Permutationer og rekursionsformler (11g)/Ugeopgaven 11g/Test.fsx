let rec a n =
    if n = 1.0 then 3.0
    else
        a(floor (n/2.0)) + a (ceil (n/2.0)) + 3.0 * n + 1.0

let k n =
    (3.0 * n * (2.0 ** n) + 4.0 * (2.0 ** n) - 1.0)

let test n =
    for i = 1 to n do
        printfn "n = %d, k = %d" i i
        printfn "a(%d) = %A" i (a (float i))
        printfn "2^%d = %A" i (k (float i))
        printfn ""

test 5
