// Week 9 Exercises

// 9.0
printfn "\n---Exercise 9.0---"

// Outputs the file (ugly)
let printFile =
  printfn "please enter filename:"
  let userInput = System.Console.ReadLine()
  let fileInput = System.IO.File.ReadAllLines(userInput)
  printfn "%A" fileInput

// Outputs the file (pretty)
let printFile2 =
  printfn "please enter filename:"
  let userInput = System.Console.ReadLine()
  let reader = System.IO.File.OpenText userInput
  while not(reader.EndOfStream) do
    let line = reader.ReadLine ()
    printfn "%s" line


// 9.1
printfn "\n---Exercise 9.1---"

let url2Stream url =
  let uri = System.Uri url
  let request = System.Net.WebRequest.Create uri
  let response = request.GetResponse ()
  response.GetResponseStream ()

let readUrl url =
  let stream = url2Stream url
  let reader = new System.IO.StreamReader(stream)
  reader.ReadToEnd ()

let url = "http://www.embak.dk"
let a = 200

let html = readUrl url
printfn "Downloaded %A. First %d characters are:\n %A" url a html



// 9.2
printfn "\n---Exercise 9.2---"

let simpleCalc =
  let mutable ans = 0
  let mutable oldAns = 0

  while true do
    printfn "%A _  _ = _"  ans
    printfn "Please enter an operator (+,-,*,/) "
    let op = System.Console.ReadLine()
    printfn "%A %s  _ = _"  ans op
    printfn "Please enter last number (no decimals)"
    let num2 = int (System.Console.ReadLine())

    let currentVal anOperator num1 =
      match anOperator with
        | "+" -> num1 + num2
        | "-" -> num1 - num2
        | "*" -> num1 * num2
        | "/" -> num1/num2
        | _   -> 0

    oldAns <- ans
    ans <- (currentVal op ans)
    printfn ""
    printfn "%A %s %A = %A"  oldAns op num2 ans
    printfn "\n"
