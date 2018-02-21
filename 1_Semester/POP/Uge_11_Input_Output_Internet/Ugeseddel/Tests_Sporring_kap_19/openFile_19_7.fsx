/// Christian Sass Hansen
/// 19.7 openFile
/// Last edited: 29/11 - 2017

let filename = "openFile_19_7.fsx"

let reader =
    try
        Some (System.IO.File.Open (filename, System.IO.FileMode.Open))
    with
        _ -> None

if reader.IsSome then
    printfn "The file %A was successfully opened." filename
    reader.Value.Close ()
