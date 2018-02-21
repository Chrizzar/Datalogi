// Christian Sass Hansen
// 3i1c
// Last modified: 06/10 - 2017

// Her tager jeg funktionerne fra opgave 3i1a og 3i1b:
// mulTable funktionen:
let mulTable n =
    let r =
        "      1    2    3    4    5    6    7    8    9   10\n" +
        " 1    1    2    3    4    5    6    7    8    9   10\n" +
        " 2    2    4    6    8   10   12   14   16   18   20\n" +
        " 3    3    6    9   12   15   18   21   24   27   30\n" +
        " 4    4    8   12   16   20   24   28   32   36   40\n" +
        " 5    5   10   15   20   25   30   35   40   45   50\n" +
        " 6    6   12   18   24   30   36   42   48   54   60\n" +
        " 7    7   14   21   28   35   42   49   56   63   70\n" +
        " 8    8   16   24   32   40   48   56   64   72   80\n" +
        " 9    9   18   27   36   45   54   63   72   81   90\n" +
        "10   10   20   30   40   50   60   70   80   90  100\n"
    if n = 10 then
        r.[0..]
    else
        r.[0..(n*53)+52]

// loopMultable funktionen:
let loopMulTable n =
    let mutable s = "      1    2    3    4    5    6    7    8    9   10\n"
    for i = 1 to n do
        s <- s + sprintf "%2d" (i)
        for j = 1 to 10 do
            s <- s + sprintf "%5d" (j*i)
        s <- s + "\n"
    s

// Her laver jeg en for-løkke der tager i fra 1 til 10, hvilket betyder at jeg laver 10 rækker fra 1 til 10. Derefter printer jeg 2 kolonner, hvor kolonne 1 er i, altså 1, 2, 3 osv. og kolonne 2 er, hvor vi sammenligner mulTable n og loopMultable n og ser om de er ens, altså om de er true eller false:
for i in 1..10 do
    printfn "%5d %5b" i (loopMulTable i = mulTable i)
