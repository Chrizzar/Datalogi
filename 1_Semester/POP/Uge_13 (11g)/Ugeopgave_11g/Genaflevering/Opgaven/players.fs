module Players
open Chess
open Pieces

[<AbstractClass>]
type Player() =
    abstract member executeMove : Board -> unit
    abstract member nextMove : Board -> unit
    abstract member playerColor : Color

type Human(col: Color) =
    inherit Player()
    let mutable _playing = true
    override this.playerColor = col

    member this.playing = _playing 

    member this.stopGame() = _playing <- false

    member this.legalMoves (tuple: int*int) =
        match tuple with
            | (num,0) -> "a" + (string((num+1)))
            | (num,1) -> "b" + (string((num+1)))
            | (num,2) -> "c" + (string((num+1)))
            | (num,3) -> "d" + (string((num+1)))
            | (num,4) -> "e" + (string((num+1)))
            | (num,5) -> "f" + (string((num+1)))
            | (num,6) -> "g" + (string((num+1)))
            | (num,7) -> "h" + (string((num+1)))
            | (_,_) -> failwith "fejl"   

    override this.nextMove(board: Board) = 
        printfn "Quit game? (y/n)"
        let ans = System.Console.ReadLine()
        match ans with
        | "n" -> this.executeMove(board)
        | "y" -> this.stopGame()
        |  _  -> failwith("'y' or 'n'")

    override this.executeMove(board: Board) =
        for i=0 to (Collections.Array2D.length1 board.BoardArray)-1 do
            for j=0 to (Collections.Array2D.length2 board.BoardArray)-1 do
                match board.BoardArray.[i, j] with
                | Some p when p.color = this.playerColor && (List.isEmpty (fst(p.availableMoves board))) && p.nameOfType = "king" ->
                    printfn "quit"
                | Some p when p.color = this.playerColor ->
                    printfn "%A: %A" p (List.map (this.legalMoves) (fst(p.availableMoves board)) |> List.map (fun elm -> (this.legalMoves (Option.get(p.position))) + " " + elm))
                | _ -> 
                    ()

        printfn "What move to do?"
        let ans = System.Console.ReadLine()

        let charToInt (charToConvert: char) = 
            match charToConvert with
            | 'a' -> 0
            | 'b' -> 1
            | 'c' -> 2
            | 'd' -> 3
            | 'e' -> 4
            | 'f' -> 5
            | 'g' -> 6
            | 'h' -> 7
            | _   -> failwith("Give a character from a-h mah dude")

        let stringToLocation (codestring: string) =
            let location = (int(codestring.[1]) - int('0')-1), charToInt(codestring.[0])
            let destination = (int(codestring.[4]) - int('0')-1), charToInt(codestring.[3])
            (location, destination)

        let moveToThis = stringToLocation ans
        board.move (fst(moveToThis)) (snd(moveToThis))
         

type Computer(col: Color) =
    inherit Player()
    let mutable playing = true
    override this.playerColor = col

    override this.nextMove(board: Board) = ()

    override this.executeMove(board: Board) =
        let mutable compList = []
        for i=0 to (Collections.Array2D.length1 board.BoardArray)-1 do
            for j=0 to (Collections.Array2D.length2 board.BoardArray)-1 do
                match board.BoardArray.[i, j] with
                | Some p when p.color = this.playerColor ->
                    compList <- compList @ [p]
                | _ -> 
                    ()
        let rnd = System.Random()
        let rndNext = rnd.Next(0, List.length compList-1)
        let rndPiece = compList.[rndNext]
        let movesList = fst(rndPiece.availableMoves board)
        printfn "%A" movesList
        let randomMove = movesList.[rnd.Next(0, List.length movesList-1)]
        let moveToThis = (Option.get(rndPiece.position), randomMove)
        board.move (fst(moveToThis)) (snd(moveToThis))