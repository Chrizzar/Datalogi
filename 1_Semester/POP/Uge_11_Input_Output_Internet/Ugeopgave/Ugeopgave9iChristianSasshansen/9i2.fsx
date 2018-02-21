/// Christian Sass Hansen
/// 19.9 webRequest
/// Last edited: 29/11 - 2017


(*
// ******** Version 1 ********

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
*)


(*
// ******** Version 2 ********

let url2Stream url =
    let uri = System.Uri url
    let request = System.Net.WebRequest.Create uri
    let response = request.GetResponse ()
    response.GetResponseStream ()

let countLinks (url:string): int =
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)

    reader.ReadToEnd ()


let url = "https://google.com"
*)


(*
// ******** Version 3 ********

open System
open System.Net
open System.Text.RegularExpressions
open System.IO

let fetchUrl (url:string) : string =
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    in reader.ReadToEnd()

let countLinks (url:string): int =
// <html>.*</html> : matches af HTMLindhold.
    let links = "<a></a>"
    let regex = url + links
    in match extract (regex)   with


do printf "Links counted from Google.com: "

let url = "https://google.com"
*)

// ******** Version 4 ********

open System
open System.IO
open System.Net
open System.Text.RegularExpressions

let fetchUrl url =
    // Setting a url up as a stream
    //let uri = System.Uri url
    try
        let request = WebRequest.Create(Uri(url))
        use response = request.GetResponse()
        let content = response.ContentType
        let regex = Regex("html").IsMatch(content)
        match regex with
            | true ->
                // Read all contens of a web page as a string
                use stream = response.GetResponseStream()
                use reader = new StreamReader(stream)
                let html = reader.ReadToEnd()
                Some html
            | false ->
                None
    with
    | _ ->
        None

// Extracts links from HTML.
let extractLinks html =
    let htmlTags = "<a><a>"


//"(?i)href\\s*=\\s*(\"|\')/?((?!#.*|/\B|mailto:|location\.|javascript:)[^\"\']+)(\"|\')"
//    let pattern2 = "(?i)^https?"

let collectLinks url =
        let html = fetchUrl url
        match html with
            | Some x -> extractLinks x
            | None -> []

let countLinks (url:string): int =
