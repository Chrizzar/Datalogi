// Listing 20.19 vectorApp.fsx
// An application using the library in file 20.20_vector.fs

open Geometry
let v = vector(Cartesian (1.0,2.0))
let w = vector(Polar (3.2,1.8))
let p = vector()
let q = vector(1.2, -0.9)
let a = 1.5
printfn "%A * %A = %A" a v (a * v)
printfn "%A + %A = %A" v w (v + w)
printfn "vector() = %A" p
printfn "vector(1.2, -0.9) = %A" q
printfn "v.dir = %A" v.dir
printfn "v.len = %A" v.len

// ******** Calling the code ********
// (fsharpc --nologo 20.20_vector.fs 20.19_vectorApp.fsx && mono 20.19_vectorApp.exe)

// Compiling and running the code from 20.19 and 20.20 will return:
// 1.5 * (1.0, 2.0) = (1.5, 3.0) 
// (1.0, 2.0) + (-1.796930596, -0.1050734582) = (-0.7969305964, 1.894926542)
// vector() = (0.0, 0.0)
// vector(1.2, -0.9) = (1.2, -0.9)
// v.dir = 1.107148718
// v.len = 2.236067977