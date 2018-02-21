(*
   Exercise 8.5
   Jan Rolandsen
*)
// E8.5.0.a
// Horners Rule:  
// f(x0) = a0 + x0 (a1 + x0 (a2 + x0 (a3 + ... + x0 (an-1 + x0 an ))...))
let poly a x : float =
    List.rev a |> List.fold ( fun acc elem -> elem + x * acc ) 0.0
;;
// testing for true
printfn "Exec 8.5.0.a"
poly [6.0] 2.0 = 6.0 ;;
poly [-3.0; 6.0] 2.0 = 9.0 ;;
poly [7.0; -3.0; 6.0] 2.0 = 25.0 ;;
poly [-3.0; 7.0; -3.0; 6.0] 2.0 = 47.0 ;;

// E8.5.0.b
let line a0 a1 x : float = 
    a0 + a1 * x
;;
// testing for true
printfn "Exec 8.5.0.b"
line 6.0 0.0 2.0 = 6.0 ;;  
line 0.0 6.0 2.0 = 12.0 ;;  
List.map ( line 3.0 4.0 ) [-2.0; -1.0; 0.0; 1.0; 2.0; 3.0; 4.0; 5.0] ;;

// E8.5.0.c
let theLine x = 
    ( line 3.0 4.0 ) x
;;
// testing for value
printfn "Exec 8.5.0.c"
List.map theLine [-2.0; -1.0; 0.0; 1.0; 2.0; 3.0; 4.0; 5.0] ;;

// E8.5.0.d
let lineA0 a0 = 
// Currying udvides altid fra højre, hvorfor fastholdt a1 og x, forhindrer a0 i at
// stå længst til højre. Vi kan indføre en hjælpefunktion, der netop flytter a0 fra
// at stå længst til højre til at stå længst til venstre:
    let flytA0 a1 x f a0 = 
        f a0 a1 x
    flytA0 4.0 2.0 line a0
;;
// testing for value
printfn "Exec 8.5.0.d"
List.map lineA0 [1.0; 2.0; 3.0; 4.0; 5.0] ;;

// E8.5.1.a
let integrate (n :int) (a :float) (b :float) f : float = 
    let deltaX = (b - a) / float n
    let interval = [a..deltaX..b]
    List.sumBy (fun elem -> elem * deltaX) (List.map f interval)
;;
// testing for value
printfn "Exec 8.5.1.a"
// analytisk er værdien = 29.16398677  (Maple)
integrate 100 0.0 System.Math.PI theLine ;;
// analytisk er værdien = 0.0  (symmetri)
integrate 100 0.0 System.Math.PI cos ;;

// E8.5.1.b
let integrateLine n = 
    integrate n 0.0 System.Math.PI theLine ;;
;;
let integrateCos n = 
    integrate n 0.0 System.Math.PI cos ;;
;;

// testing for value
printfn "Exec 8.5.1.b"
let L1 = List.map integrateLine [1; 10; 100; 1000] ;;
List.map (fun elem -> elem - 29.16398677) L1 ;;

let L2 = List.map integrateCos [1; 10; 100; 1000] ;;
List.map (fun elem -> elem - 0.0) L2 ;;

// E8.5.2.a
let rec fac n = 
    match n with
        | n when n < 1 -> raise (System.ArgumentException "Fejl: n < 1")
        | n when n = 1 -> 1
        | _ -> n * fac (n - 1)
;;
// testing for value
printfn "Exec 8.5.2.a"
try fac -4 with 
    | :? System.ArgumentException as ex-> printfn "%s" ex.Message ; -4 ;;

try fac 0 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; -0 ;;

try fac 1 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; 1 ;;

try fac 4 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; 4 ;;

// E8.5.2.b
// definerer min egen exception:
exception ArgumentTooBig of string ;;
let rec facB n = 
    match n with
        | n when n < 1 -> raise (System.ArgumentException "Fejl: n < 1")
        | n when n = 1 -> 1
        | n when n > 50 -> raise (ArgumentTooBig "Calculation would result in an overflow !")        
        | _ -> n * facB (n - 1)
;;
// testing for value
printfn "Exec 8.5.2.b"
try facB -4 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; -4 ;;

try facB 0 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; -0 ;;

try facB 1 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; 1 ;;

try facB 4 with 
    | :? System.ArgumentException as ex -> printfn "%s" ex.Message ; 4 ;;

try facB (50 + 1) with 
    | ArgumentTooBig msg -> printfn "%s" msg ; -50 ;;

// E8.5.2.c
let rec facFailwith n = 
    match n with
        | n when n < 1 -> failwith "Argument must be greater than 0 !"
        | n when n = 1 -> 1
        | n when n > 50 -> failwith  "Calculation would result in an overflow !"
        | _ -> n * facFailwith (n - 1)

;;
// testing for value
printfn "Exec 8.5.2.c"
try facFailwith -4 with 
    | Failure msg -> printfn "%s" msg ; -4 ;;

try facFailwith 0 with 
    | Failure msg -> printfn "%s" msg ; -0 ;;

try facFailwith 1 with 
    | Failure msg -> printfn "%s" msg ; 1 ;;

try facFailwith 4 with 
    | Failure msg -> printfn "%s" msg ; 4 ;;

try facFailwith (50 + 1) with 
    | Failure msg -> printfn "%s" msg ; -50 ;;

// E8.5.3.a

// Vi kan altid beregne værdien iterativt og derefter caste resultatet til int option
// f.eks. kan vi give ugyldige inddata returværdien -1, og så caste til None.
// Nedenstående løsning er rekursiv og benytter Option.get samt Option.bind
let rec facOption n : int option = 
    match n with
        | x when x < 1 -> None
        | 1 -> Some 1
        | x -> Some ( x * Option.get ( facOption (n - 1) ) )
;;
// testing for value
printfn "Exec 8.5.3.a"
List.map facOption [-4; 0; 1; 4] ;;

// E8.5.3.b
let logIntOption n : float option = 
    match n with
        | x when x > 0 -> Some (log (float x))    // log er identisk med ln
        | _ -> None
;;
// testing for value
printfn "Exec 8.5.3.b"
List.map logIntOption [-10; 0; 1; 10] ;;

// E8.5.3.c
let logFac n : float option = 
    Option.bind (logIntOption) (facOption n)
;;
// testing for value
printfn "Exec 8.5.3.c"
let xs = [1; 2; 4; 8] ;;
let stirling = List.map (fun x -> (float x) * log (float x) - (float x) ) xs ;;
let logfac = List.map logFac xs |> List.map Option.get ;;
// logfac - stirling ;;
List.zip logfac stirling |> List.map (fun (x,y) -> x - y ) ;;


// E8.5.3.d
printfn "Exec 8.5.3.d"
let n = 4 ;;
let t1 = Option.bind logIntOption (facOption n) ;;        // 1. udtryk
let t2 = (facOption >> (Option.bind logIntOption)) n ;;   // 2. udtryk
let t3 = n |> facOption |> Option.bind logIntOption ;;    // 3. udtryk

// slut
