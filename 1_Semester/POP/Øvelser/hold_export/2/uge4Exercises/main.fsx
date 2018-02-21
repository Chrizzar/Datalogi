// This is the Fsharp file
// How to run it with a .dll
// $ fsharpi -r test.dll main.fsx
// OR
// include #r "test.dll" in your .fsx file and run
// $ fsharpi test.fsx

//#r "test.dll"


let colorTwo:color.aColor = (50, 42, 150)
let colorOne:color.aColor = (50, 32, 210)

printfn "%A" (color.add colorOne colorTwo)
printfn "%A" (color.scale colorOne colorTwo)
printfn "%A" (color.gray colorOne)
