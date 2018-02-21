open Chess
open Pieces
open Players
open System.Xml
open System.Drawing.Imaging


type Game(board: Board) = 
    let pieces = [|
        king (White) :> chessPiece;
        rook (White) :> chessPiece;
        rook (White) :> chessPiece;
        king (Black) :> chessPiece;
        rook (Black) :> chessPiece;
        rook (Black) :> chessPiece |]
        
    do board.[7,3] <- Some pieces.[0]
    do board.[7,0] <- Some pieces.[1]
    do board.[7,6] <- Some pieces.[2]
    do board.[0,4] <- Some pieces.[3]
    do board.[0,1] <- Some pieces.[4]
    do board.[0,7] <- Some pieces.[5]
    do printfn "%A" board
    
    member this.play() = 
        printfn "White is the big letters (K, R) and Black is the small letters (k, r)"
        printfn "Human playing as Black or white?"

        let humanColor = 
            match System.Console.ReadLine() with
            | "Black" -> Black
            | "black" -> Black
            | "b"     -> Black
            | "White" -> White
            | "white" -> White
            | "w"     -> White
            | _       -> failwith("Chose Black or White")

        let player1 = new Human(humanColor) 

        let player2Color = 
            match player1.playerColor with
            | White -> Black
            | Black -> White

        let player2 = new Computer(player2Color)
        

        while player1.playing do

            player1.nextMove(board)
            printfn "%A" board

            match player1.playing with
            | true -> 
                player2.executeMove(board)
                System.Console.Clear()
                printfn "%A" board
            | false -> ()    

let main() =    
    
    let chessBoard = new Chess.Board ()
    let currentGame = new Game(chessBoard)
    currentGame.play()

main()