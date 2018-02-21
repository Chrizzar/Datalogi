/// Christian Sass Hansen
/// 9i1
/// Last edited: 06/12 - 2017

open System
open System.IO

/// XMLdoc header for file fileReplace:

/// <summary> The Function fileReplace, replaces all occurrences of the "needle" argument with the "replace" argument in the file "filename" </summary>
/// <remarks> This program will create a temp file, where the results of all the changes will be put in <remarks>
/// <param name="filename"> The arguemnt filename, let's you choose a file (string) </param>
/// <param name="needle"> The argument "needle" is a string, which you use to choose a word from the file you have chosen, you want to be replaced (string) </param>
/// <param name="replace"> The argument "replace" is a string, where you choose the word, which replaces the needle argument (string) </param>
/// <returns> The changes to the file (A chosen word replace by another) </returns>
/// <example> The following call: <code> fileReplace () </code>
/// Will return:
///      What file do you want me to open?
///      9i1TextFile.txt
///      What word do you want to replace?
///      Dogs
///      What word do you want to insert?
///      Cats
///
/// Which returns a temp file with:
/// Cats always lands on their feet
/// Cats always barks alot
/// </example>

let fileReplace () =
    Console.WriteLine("What file do you want me to open?")
    let filename = Console.ReadLine ()

    Console.WriteLine("What word do you want to replace?")
    let needle = Console.ReadLine ()

    Console.WriteLine("What word do you want to insert?")
    let replace = Console.ReadLine ()

    try
        let oldFile = IO.File.OpenText filename
        let newFile = IO.File.CreateText("Temp.txt")

        while (not oldFile.EndOfStream) do
            // Bind the next line to the value 'line'
            // This goes into the filen and saves the first line, and then use that line
            // It does that until it reaches the bottom of the file
            let line = oldFile.ReadLine()

            // Deleting the argument "needle" and
            // replacing the argument "needle" with "replace"
            let newLine = line.Replace (needle, replace)

            // Write the new line to the console
            newFile.WriteLine(newLine)

        // Closing the stream newFile and oldFile
        if oldFile.EndOfStream then newFile.Close()
        if oldFile.EndOfStream then oldFile.Close()

    with
        | :? System.IO.FileNotFoundException ->
            Console.WriteLine("File was not found!")

        | _ -> Console.WriteLine("An unknown error has occurred!")

fileReplace ()
