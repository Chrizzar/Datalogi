/// Made by: Christian S. Hansen, Daniel N. Krog og Michael K. Olesen
/// Last Edited: 13-10-2017

// *** Længden af vektor ***
let vector1 = (4.0,3.0)
let vector2 = (0.0,0.0)
let vector3 = (-1.5,-3.0)

printfn "Unit: len"
printfn "Length of %A. Expected: %2f. Actual: %2f" (vector1) (5.0) (vec2d.len vector1) 
printfn "Length of %A. Expected: %2f. Actual: %2f" (vector2) (0.0) (vec2d.len vector2) 
printfn "Length of %A. Expected: %2f. Actual: %2f" (vector3) (3.354102) (vec2d.len vector3) 

// *** Vinkel mellem 2 vektorer ***

printfn "Unit: ang"
printfn "Direction of %A. Expected: %2f. Actual: %2f" (vector1) (0.64) (vec2d.ang vector1)
printfn "Direction of %A. Expected: %2f. Actual: %2f" (vector2) (0.00) (vec2d.ang vector2)
printfn "Direction of %A. Expected: %2f. Actual: %2f" (vector3) (-2.03) (vec2d.ang vector3)

// *** Multiplikation for en float og en vektor ***

let scaleConstant = 5.0
printfn "Unit: scale"
printfn "Scaling the vector %A with %f. Expected: %A. Actual: %A" (vector1) (scaleConstant) (20.0, 15.0) (vec2d.scale scaleConstant vector1)
printfn "Scaling the vector %A with %f. Expected: %A. Actual: %A" (vector2) (10.0*scaleConstant) (0.0, 0.0) (vec2d.scale (10.0*scaleConstant) vector2)
printfn "Scaling the vector %A with %f. Expected: %A. Actual: %A" (vector3) (-1.0*scaleConstant) (7.5, 15.0) (vec2d.scale (-1.0*scaleConstant) vector3)


// *** Addition med vektorer ***

printfn "Unit: add"
printfn "Adding the vectors %A and %A. Expected: %A. Actual: %A" (vector1) (vector2) (4.0, 3.0) (vec2d.add vector1 vector2)
printfn "Adding the vectors %A and %A. Expected: %A. Actual: %A" (vector1) (vector3) (2.5, 0.0) (vec2d.add vector1 vector3)
printfn "Adding the vectors %A and %A. Expected: %A. Actual: %A" (vector3) (vector2) (-1.5, -3.0) (vec2d.add vector3 vector2)


// *** Prikproduktet for 2 vektorer ***

printfn "Unit: dot"
printfn "Dot product of %A and  %A. Expected: %2f. Actual: %2f" (vector1) (vector2) (0.0) (vec2d.dot vector1 vector2) 
printfn "Dot product of %A and  %A. Expected: %2f. Actual: %2f" (vector1) (vector3) (-15.0) (vec2d.dot vector1 vector3) 
printfn "Dot product of %A and  %A. Expected: %2f. Actual: %2f" (vector3) (vector2) (0.0) (vec2d.dot vector3 vector2) 
