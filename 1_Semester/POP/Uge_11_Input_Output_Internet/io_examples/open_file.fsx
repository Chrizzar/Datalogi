open System


/// <summary>Asks the user for a filename</summary>
/// <returns>filename as string option</returns>
let getFilename ():string option =
    // Ask the user for a filename
    Console.WriteLine("What file should i print?")
    // Bind the filename
    let filename = Console.ReadLine ()
    // If user entereded 'exit', return None so we can exit
    if filename = "exit" then
        None
    // If user entered something, return that something as a string option
    else
        Some filename


/// <summary>Asks the user for a file, prints file contents</summary>
let print_file () =
    // try to get a filename from the user
    let (filename:string option) = getFilename ()

    match filename with
        // If user entered 'exit', filename is None, and we should exit
        // Printing returns a unit, so printing will exit as print_file has signature unit -> unit
        | None -> Console.WriteLine ("Exiting...")
        // if user entered something, we should try to open the file
        | Some filename ->
            // Entering exception county
            try
                // Print a message to the user, stating what file we are trying to open
                Console.WriteLine(sprintf "Trying to open file '%s'" filename)
                // Try to open it. This is where things might go wrong and an exception can be thrown!

                // use IO.File.OpenText to open a file for the user.
                // val file : IO.StreamReader
                // file has the type IO.StreamReader. Think of this as a
                // possibly infinite list of strings, which we can loop through
                // and do something with, line by line
                let file = IO.File.OpenText filename

                // A IO.StreamReader object has attributes, e.g
                // EndOfStream. file.EndOfStream is a boolean.
                // It will be false, until the last byte of the file is read
                // by looping through the file (e.g. with ReadLine() )
                // putting 'not' in front of a boolean, negates it
                // not true = false
                // not false = true
                //
                // Loop through the file, as long as there is any lines left
                while (not file.EndOfStream)  do
                    // Bind the next line to the value 'line'
                    let line = file.ReadLine()
                    // Write the line to the console
                    Console.WriteLine(line)

            // Since we do IO, things can go wrong. We need to 'catch' our exceptions
            // Remember that exceptions are EXPECTED deviations from the
            // "successful" program flow. We need to know what to do when things go wrong.
            // An exception should never 'come by surprise'
            with
                // :? just means 'match an exception'
                // System.IO.FileNotFoundException is 'thrown', when we
                // try to open a file that does not exist
                | :? System.IO.FileNotFoundException ->
                    // If we matched on FileNotFoundException, we can tell the user
                    // That the file was not fine.
                    // This will 'return' unit, and exit
                    Console.WriteLine("File was not found!")
                // Catch any exception
                // We should still handle everything that can go wrong
                // Here we 'cheat', and catch all exceptions that can happen
                | _ -> Console.WriteLine("Unknown error occurred!")


// Call the function starting the dialogue
print_file ()
