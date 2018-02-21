/// Christian Sass Hansen
/// 19.9 webRequest
/// Last edited: 29/11 - 2017

// Set a url up as a stream
let url2Stream url =
    let uri = System.Uri url
    let request = System.Net.WebRequest.Create uri
    let response = request.GetResponse ()
    response.GetResponseStream ()

// Read all contents of a web page as a string
let readUrl url =
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd ()

let url = "http://fsharp.org"
let a = 400

let html = readUrl url
printfn "Downloaded %A. First %d characters are: %A" url a html.[0..a]
