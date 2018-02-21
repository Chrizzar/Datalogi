(*
   DMA, Uge 11, Relationer
   Jan Rolandsen
*)

// OBS: Datatypen <list> egner sig ikke specielt godt som repr�sentation af m�ngder.
//      Lister kan indeholde samme element flere gange, hvilket ikke er tilladt i en
//      m�ngden. I F# er m�ngder repr�senteret af datatypen <set>.
//      I F# er der en brugbar datatype ved navn <seq> for collections (sekvenser).
//      Heldigvis kan vi transformere frem-og-tilbage mellem <list> og <set> og <seq>

// M�ngder (datatypen list):
let A = [3 .. 6] ;;
let B = [1 .. 15] ;;

// Karteisk produkt af m�ngder:
let rec cartesian xs ys =
    match xs, ys with
        | _ , []       -> []
        | [] , _       -> []
        | x :: tail, _ -> (List.map (fun y -> x, y) ys) @ (cartesian tail ys)
;;
// Identisk med ovenst�ende:
let cartesian' xs ys =
    xs |> List.collect (fun x -> ys |> List.map (fun y -> x, y))
;;
// Produkt m�ngden:
let AxB = cartesian A B ;;
let AxB' = cartesian' A B ;;
printfn "%b" (AxB = AxB') ;;

// Relation: a R b betyder "a g�r op b"
let aRb = List.filter (fun (a,b) -> b % a = 0) AxB ;;

let relation xs R ys =
    List.filter R (cartesian xs ys)
;;

// Relationen "a g�r op b"
let R = fun (a,b) -> b % a = 0 ;;

let aRb' = relation A R B ;;
printfn "%b" (aRb = aRb') ;;

// Relationen "b g�r op a"
let bRa = relation B R A ;;
printfn "%A" bRa ;;

// Domain Dom(R)
let dom xs =
    xs |> (List.map fst >> List.distinct)
;;
dom aRb ;;

// Identisk med ovenst�ende:
let dom' xs =
    xs |> List.map fst |> List.distinct
;;
dom' aRb ;;

// Range Ran(R)
let ran xs =
    xs |> (List.map snd >> List.distinct)
;;
ran aRb ;;

// Union(A, B) er foreningsm�ngden
let union xs ys =
     Set.union (Set.ofList xs) (Set.ofList ys) |> Set.toList
;;
union aRb bRa ;;

// Intersect(A, B) er f�llesm�ngden
let intersect xs ys =
     Set.intersect (Set.ofList xs) (Set.ofList ys) |> Set.toList
;;
intersect aRb bRa ;;

// end
