open Pieces



let newMoves() = 


type Human() =
    inherit Player()
    member this.nextMove(board : Board) : string =
        let hMoves = fst(p.availableMoves)
        for i = 0 to (fst(hMoves)) do
            match hMoves with
            | (0,num) -> "a" (string(num))
            | (1,num) -> "b" (string(num))
            | (2,num) -> "d" (string(num))
            | (3,num) -> "e" (string(num))
            | (4,num) -> "f" (string(num))
            | (5,num) -> "g" (string(num))
            | (6,num) -> "h" (string(num))
            | _ -> failwith "fail"


// type Computer() =
//    inherit Player()
//    member this.nextMove()