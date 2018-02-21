open Chess
open Pieces
open Players

/// Print various information about a piece
let printPiece (board : Board) (p : chessPiece) : unit =
  printfn "%A: %A" p (p.availableMoves board)
//  printfn "%A: %A %A" p p.position (p.availableMoves board)

// Create a game
let board = Chess.Board () // Create a board
// Pieces are kept in an array for easy testing
let pieces = [|
  king (Black) :> chessPiece;
  rook (Black) :> chessPiece;
  rook (White) :> chessPiece |]

// Place pieces on the board
board.[0,0] <- Some pieces.[0]
board.[1,2] <- Some pieces.[1]
board.[0,2] <- Some pieces.[2]

// board.[1,1] <- Some pieces.[1]
// board.[4,1] <- Some pieces.[2]

printfn "%A" board
//Array.iter (printPiece board) pieces

let player1 =
    new Human(Black)
let player2 =
    new Computer(White)
let Moving = player1.nextMove(board)

board.move (fst(Moving)) (snd(Moving))
printfn "%A" board
printfn "%A" Moving
let compMove = player2.nextMove(board)
board.move (fst(compMove)) (snd(compMove))
printfn "%A" board
printfn "%A" compMove
// Make moves
//board.move (1,1) (3,1) // Moves a piece from (1,1) to (3,1)