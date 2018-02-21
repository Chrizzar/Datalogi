/// Made by: Christian S. Hansen, Daniel N. Krog og Michael K. Olesen
/// Last Edited: 13-10-2017

/// <summary> 4g.2a) Summen af alle siderne i en polygon med n sider.</summary>
/// <remarks> Denne funktion gjorde tidligere brug af afstand.dll, den bruger dog vec2d.dll nu.</remarks>
/// <param name="n"> Antallet af sider som det ønskes polygon skal have.</param>
/// <returns> Summen af længderne af polygonens sider (Polygonens omkreds).</returns>
let polyLen n =

    let mutable counter = 0.0
    let mutable typeCastN = 0.0

    let mutable sum = 0.0
    let mutable Oi = 0.0
    let mutable prevpunkt = (0.0, 0.0)
    let mutable nextpunkt = (0.0, 0.0)
    let pi = System.Math.PI

    for i = 0 to n-1 do
        counter <- float i
        typeCastN <- float n

        if i = n-1 then
            Oi <- ((2.0*pi*counter)/typeCastN)
            prevpunkt <- (cos Oi,sin Oi)
            // printfn "%A" prevpunkt

            Oi <- ((2.0*pi*0.0)/typeCastN)
            nextpunkt <- (cos Oi,sin Oi)
            // printfn "%A" nextpunkt

            sum <- sum + vec2d.afstandsFormel prevpunkt nextpunkt

        else
            Oi <- ((2.0*pi*counter)/typeCastN)
            prevpunkt <- (cos Oi,sin Oi)
            // printfn "%A" prevpunkt

            Oi <- ((2.0*pi*(counter+1.0))/typeCastN)
            nextpunkt <- (cos Oi,sin Oi)
            // printfn "%A" nextpunkt 

            sum <- sum + vec2d.afstandsFormel prevpunkt nextpunkt 

    sum

/// <summary> Funktion som udskriver en tabel med resultaterne af polyLen(n).</summary>
/// <param name="tableRows"> Antallet af rækker som tabellen skal have.</param>
/// <returns> En tabel med omkredsen af polygonerne fra n=2 til n.</returns>
let tableFunc (tableRows: int) = 
    printfn "PolygonOmkreds\tCirkelOmkreds\tn\n"
    
    for i = 2 to tableRows do
        printfn "%f\t%f\t%d" (polyLen i) 6.283185308 i 

tableFunc 20


/// <summmary> 4g.2b) Når n er gående mod uendelig, vil den langsomt nærme sig enhedscirklens omkreds.</summary>

