// *** Længden af vektor ***
let vector1 = vec2d.len (4.0,3.0)
let vector2 = vec2d.len (0.0,0.0)
let vector3 = vec2d.len (-1.5,-3.0)

printfn "Unit: len"
printfn "%f" vector1
printfn "%f" vector2
printfn "%f" vector3


// *** Vinkel mellem 2 vektorer ***
let vector4 = vec2d.ang (4.0, 3.0)
let vector5 = vec2d.ang (0.0, 0.0)
let vector6 = vec2d.ang (-1.5, -3.0)

printfn "Unit: ang"
printfn "%f" vector4
printfn "%f" vector5
printfn "%f" vector6


// *** Multiplikation for en float og en vektor ***
let vector7 = vec2d.scale 5.0 (4.0, 3.0)
let vector8 = vec2d.scale 5.0 (1.0, 1.0)
let vector9 = vec2d.scale 5.0 (1.5, 3.0)

printfn "Unit: scale"
printfn "%A" vector7
printfn "%A" vector8
printfn "%A" vector9


// *** Addition med vektorer ***
let vector10 = vec2d.add (4.0, 3.0)  (4.0, 3.0)
let vector11 = vec2d.add (4.0, 3.0)  (4.0, 3.0)
let vector12 = vec2d.add (4.0, 3.0)  (4.0, 3.0)

printfn "Unit: add"
printfn "%A" vector10
printfn "%A" vector11
printfn "%A" vector12


// *** Prikproduktet for 2 vektorer ***
let vector13 = vec2d.dot (4.0,3.0) (3.0,4.0)
let vector14 = vec2d.dot (1.0,0.0) (1.0,2.0)
let vector15 = vec2d.dot (-1.5,-3.0) (5.0,6.0)

printfn "Unit: dot"
printfn "%f" vector13
printfn "%f" vector14
printfn "%f" vector15
