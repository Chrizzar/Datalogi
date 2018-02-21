/// Christian Sass Hansen
/// 19.8 readFile
/// Last edited: 29/11 - 2017

let printFile (reader : System.IO.StreamReader) =
    while not(reader.EndOfStream) do
        let line = reader.ReadLine ()
        printfn "%s" line

let filename = "readFile_19_8.fsx"
let reader = System.IO.File.OpenText filename
printFile reader
