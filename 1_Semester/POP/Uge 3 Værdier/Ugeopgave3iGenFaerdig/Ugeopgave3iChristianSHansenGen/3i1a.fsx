// Christian Sass Hansen
// 3i1a
// Last modified: 06/10 - 2017

// Her laver jeg funktionen mulTable til n
let mulTable n =
    // Jeg starter med at definere en streng, der skal indeholde en lokal værdibining, med en enkelt streng der indeholder 10 tabeller, 1 - 10 tabellen. Hvor jeg teknisk set lavet 10 strenge, men plusser dem sammen så de bliver en streng:
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
        // Her laver jeg en streng-indicering fra 0 og til enden af strengen, altså [0..]. Så 0 til 100
        r.[0..]
    // Så laver jeg en else, der gælder for alle andre tal mindre end n lig med 10
    else
        r.[0..(n*53)+52]
        // I streng indiceringen sætter vi [0..(n*53)+53], hvilket betyder eksempelvis hvis vi siger n = 1. n = 1 er alene bare rækken n. Derved sætter vi n*53, da der er 53 spaces fra starten af "strengene" og til slutningen mellem det sidste tal og backspace. Derefter plusser jeg det med 52, da vi også skal have rækken nedenunder med. Der plusses med 52, fordi så tager vi rækken nedenunder med, uden linjeskiftet.
        // Hvis vi bare siger n*53, så får vi kun den første række "n" med, uden selve 1-tabellen.

// Her printer jeg så strengen i funktionen mulTable, der printer tabeller hvor n = 1, n = 2, n = 3, n = 4, n = 4, n = 5, n = 6 og n = 10:
printfn "%s" "Her er n = 1"
printfn "%s" (mulTable 1)
printfn "%s" "Her er n = 2"
printfn "%s" (mulTable 2)
printfn "%s" "Her er n = 3"
printfn "%s" (mulTable 3)
printfn "%s" "Her er n = 4"
printfn "%s" (mulTable 4)
printfn "%s" "Her er n = 5"
printfn "%s" (mulTable 5)
printfn "%s" "Her er n = 6"
printfn "%s" (mulTable 6)
printfn "%s" "Her er n = 10"
printfn "%s" (mulTable 10)
