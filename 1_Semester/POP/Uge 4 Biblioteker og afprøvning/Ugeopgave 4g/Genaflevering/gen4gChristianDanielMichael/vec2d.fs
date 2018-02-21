/// A 2 dimensional vector library.
/// Vectors are represented as pairs of floats (x y)
module vec2d

/// The length of a vector
// XMLdoc header len:
/// <summary> The function len will return the length of a vector.</summary>
/// <param name="x"> x-cordinate for the vector (float) </param>
/// <param name="y"> y-cordinate for the vector (float) </param>
/// <returns> The length of the vector (float) <returns>
let len ((x: float),y) =
    sqrt (x*x+y*y)

/// <summary> Find vinklen af en en vektor med kordinaterne (x,y).</summary>
/// <param name="x"> x-kordinaten for vektoren.</param>
/// <param name="y"> y-kordinaten for vektoren.</param>
/// <returns> Vinklen af en vektor som float.<returns>
let ang ((x:float),y) =
    atan2 y x

/// <summary> Skaler en vektor med konstanten 'a'.</summary>
/// <param name="x"> x-kordinaten for vektoren.</param>
/// <param name="y"> y-kordinaten for vektoren.</param>
/// <param name="a"> konstanten som vektoren forlænges/forkortes med.</param>
/// <returns> En ny vektor som er blevet forlænget/forkortet.<returns>
let scale (a : float) (tup : float * float) : float * float =
    let newTupe = ((fst(tup)*a), (snd(tup)*a))
    newTupe

/// <summary> Læg to vektorer sammen ved at lægge deres vektorkordinater sammen.</summary>
/// <param name="x1"> x-kordinaten for den første vektor.</param>
/// <param name="y1"> y-kordinaten for den første vektor.</param>
/// <param name="x2"> x-kordinaten for den anden vektor.</param>
/// <param name="y2"> y-kordinaten for den anden vektor.</param>
/// <returns> En ny vektor.<returns>
let add ((x1: float),y1 : float) ((x2 : float),y2 : float) =
    let newTupe = ((x1 + x2), (y1 + y2))
    newTupe

/// <summary> Udregn prikproduktet/dotproduktet af to vektorer.</summary>
/// <param name="x1"> x-kordinaten for den første vektor.</param>
/// <param name="y1"> y-kordinaten for den første vektor.</param>
/// <param name="x2"> x-kordinaten for den anden vektor.</param>
/// <param name="y2"> y-kordinaten for den anden vektor.</param>
/// <returns> Prikproduktet af to vektorer.<returns>
let dot ((x1: float),y1: float) ((x2: float),y2: float) =
    (x1*x2) + (y1*y2)

/// <summary> Udregn distancen mellem to punkter </summary>
/// <param name="fstTup"> Vektor1 repræsenteret i en tuple </param>
/// <param name="sndTup"> Vektor2 repræsenteret i en tuple </param> 
/// <returns> Distancen mellem to punkter som float </returns>
let afstandsFormel (fstTup: float * float) (sndTup: float * float) : float =
    // printfn"(%A, %A) (%A, %A)" (fst fstTup) (fst sndTup) (snd fstTup) (snd sndTup)
    let xVal = ((fst fstTup-fst sndTup)**2.0)
    let yVal = ((snd fstTup-snd sndTup)**2.0)
    let afstandToPunkt = (abs(sqrt((xVal+yVal))))
    afstandToPunkt
