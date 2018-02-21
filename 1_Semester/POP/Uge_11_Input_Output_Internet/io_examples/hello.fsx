// Open System, so we can use Console.WriteLine and Console.ReadLine
open System

// Print a message and a question to the user
Console.WriteLine("What a jolly day to take input. What's your name lad?")
// Save the users input to the value 'name'
let name = Console.ReadLine ()
// Print a greeting to the user
Console.WriteLine(sprintf "Well hello, %s" name)

