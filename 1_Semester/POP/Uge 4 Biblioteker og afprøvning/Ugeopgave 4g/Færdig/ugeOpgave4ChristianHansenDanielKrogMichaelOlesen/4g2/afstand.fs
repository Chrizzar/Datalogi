module afstand

let afstandsFormel (fstTup: float * float) (sndTup: float * float) : float =
    // printfn"(%A, %A) (%A, %A)" (fst fstTup) (fst sndTup) (snd fstTup) (snd sndTup)
    let xVal = ((fst fstTup-fst sndTup)**2.0)
    let yVal = ((snd fstTup-snd sndTup)**2.0)
    let afstandToPunkt = (abs(sqrt((xVal+yVal))))
    afstandToPunkt
