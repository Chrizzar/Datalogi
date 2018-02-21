
// 3.0
printfn "\n---Exercise 3.0---"
let a = 3
let b = 4
let x = 5
printfn"%A * %A + %A = %A" a x b (a * x + b)
let y = a * x + b
printfn"%A * %A + %A = %A" a x b (y)


// 3.1
printfn "\n---Exercise 3.1---"
let y2 = a * x + b in
printfn"%A * %A + %A = %A" a x b (y2)


// 3.2
printfn "\n---Exercise 3.2---"
let firstName = "Jon"
let lastName = "Sporring"
let name = firstName + " " + lastName
printfn "Hello %A!" name

let fName = "Jon" in let lName = "Sporring" in printfn "One-liner %A!" (fName + " " + lName)


// 3.3
printfn "\n---Exercise 3.3---"
let f a x b =
    a*x+b
printfn"%A * %A + %A = %A" a x b ( f a x b )


// 3.4
printfn "\n---Exercise 3.4---"
printfn "No loop"
printfn"%A * %A + %A = %A" a 0 b ( f a 0 b )
printfn"%A * %A + %A = %A" a 1 b ( f a 1 b )
printfn"%A * %A + %A = %A" a 2 b ( f a 2 b )
printfn"%A * %A + %A = %A" a 3 b ( f a 3 b )
printfn"%A * %A + %A = %A" a 4 b ( f a 4 b )
printfn"%A * %A + %A = %A" a 5 b ( f a 5 b )

printfn "For loop"
for n in [0..5] do
    printfn"%A * %A + %A = %A" a n b ( f a n b )

printfn "While loop"
let mutable counter = 0
while (counter <= 5) do
    printfn"%A * %A + %A = %A" a counter b ( f a counter b )
    counter <- counter+1   


// 3.5
printfn "\n---Exercise 3.5---"

for a1 in ([1]@[1..10]) do
    for a2 in ([1]@[1..10]) do
        printf "%4i" (a1*a2)
    printf "\n"


// 3.6
printfn "\n---Exercise 3.5---"

let fac n =
    let mutable loop = n
    let mutable cm = 1
    while (loop > 0) do
        cm <- cm * loop
        loop <- loop-1
    cm

let fac64 n =
    let mutable loop = n
    let mutable cm:int64 = 1L
    while (loop > 0) do
        cm <- (cm * int64(loop))
        loop <- loop-1
    cm

printfn "%A" (fac 13)
printfn "%A" (fac64 13)
