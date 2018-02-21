/// Christian Sass Hansen
/// 9i2 webRequest
/// Last edited: 13/12 - 2017

// ******** Version 1 (Working) ********

open System
open System.IO
open System.Text.RegularExpressions

/// XMLdoc header for file countLinks:

/// <summary> The funtion countLinks, will download a website given with an argument "url" and which will count,
/// how many links, there are on the page by counting the "<a strings" </summary>
/// <remarks> This function uses regularexpressions, to find and match which are links in the html by the parameter "<a href=" string. <remarks>
/// <param name="url"> The parameter url is a string, which will contain the website.
/// The paramater "url" will be used in getting access to the website, so the program can read all characters from the current position to the end of the stream.
/// Then by that find the links and count them. (string) </param>
/// <returns> The program will return the count of links, which are located on a website, in form of an integer (int) </returns>
/// <example> The following call (from the website: "http://google.com"): <code> countLinks web </code>
/// Will return: 10 links </example>

// string -> int                                                           // Signature
let countLinks (url: string): int =                                   // Definition

    /// XMLdoc header for file url2Stream:

    /// <summary> The funtion urls2Stream, will connect to a url as stream. But to do so, it first needs the format URL string, as a URI, using the System.Uri funtion.
    /// Then it initializes the request by the System.Net.WebRequest function, and the response from the host is obtained by the GetResponse method. </summary>
    let url2Stream url =
        let uri = System.Uri url
        let request = System.Net.WebRequest.Create uri
        let response = request.GetResponse ()
        response.GetResponseStream ()

    /// XMLdoc header for file readUrl:

    /// <summary> The function readUrl, will get us to access the response as a stream by the GetResponseStream method.
    /// Thereafter we convert the stream to a streamReader so the program can read all characters from the current
    /// position to the end of the stream with the ReadToEnd method. </summary>
    let readUrl url =
        let stream = url2Stream url
        let reader = new System.IO.StreamReader(stream)
        reader.ReadToEnd ()

    let html = readUrl url
    let links = Regex.Matches (html, "<a href=")
    links.Count

// The chosen website
let web = "http://google.com"

printfn "\nLinks counted from the website: %s" web
printfn "%d links" (countLinks web)




(*
// ******** Version 2 (Working) ********

open System
open System.IO
open System.Text.RegularExpressions


// Set a url up as a stream
// string -> System.IO.Stream
let url2Stream url =
    let uri = System.Uri url
    let request = System.Net.WebRequest.Create uri
    let response = request.GetResponse ()
    response.GetResponseStream ()


// Read all contents of a web page as a string
// 'a -> string
let readUrl url =
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd ()

(*
let countLinks (url:string): int =
    let r = new Regex <a\s+href=\s*"[a-zA-Z1-9.]">
    let mutable count = 0
*)

let url = "http://google.com"
let html = readUrl url

let countLinks =
    Regex.Matches (html, "<a href=")

printfn "\nLinks counted from the website: %s" url
printfn "%A" (countLinks.Count)

*)

(*
// ******** Version 3 ********

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
// ******** Version 4 ********

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
// ******** Version 5 ********

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

// ******** Version 6 ********
(*
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
              //  let html = reader.ReadToEnd()
              //  Some html
                reader.ReadToEnd()
            | false ->
                None
    with
    | _ ->
        None
*)

(*
// Extracts links from HTML.
let extractLinks html =
    let htmlTags = "<a><a>"


let collectLinks url =
        let html = fetchUrl url
        match html with
            | Some x -> extractLinks x
            | None -> []

let countLinks (url:string): int =
*)
