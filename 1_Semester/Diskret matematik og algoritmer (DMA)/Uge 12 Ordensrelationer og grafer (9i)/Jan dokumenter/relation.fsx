(*
   DMA, Uge 11, Relationer
   Jan Rolandsen
*)

// OBS: Datatypen <list> egner sig ikke specielt godt som repræsentation af mængder.
//      Lister kan indeholde samme element flere gange, hvilket ikke er tilladt i en
//      mængden. I F# er mængder repræsenteret af datatypen <set>.
//      I F# er der en brugbar datatype ved navn <seq> for collections (sekvenser).
//      Heldigvis kan vi transformere frem-og-tilbage mellem <list> og <set> og <seq>

// Mængder (datatypen list):
let A = [3 .. 6] ;;
let B = [1 .. 15] ;;

// Karteisk produkt af mængder:
let rec cartesian xs ys =
    match xs, ys with
        | _ , []       -> []
        | [] , _       -> []
        | x :: tail, _ -> (List.map (fun y -> x, y) ys) @ (cartesian tail ys)
;;
// Identisk med ovenstående:
let cartesian' xs ys =
    xs |> List.collect (fun x -> ys |> List.map (fun y -> x, y))
;;
// Produkt mængden:
let AxB = cartesian A B ;;
let AxB' = cartesian' A B ;;
printfn "%b" (AxB = AxB') ;;

// Relation: a R b betyder "a går op b"
let aRb = List.filter (fun (a,b) -> b % a = 0) AxB ;;

let relation xs R ys =
    List.filter R (cartesian xs ys)
;;

// Relationen "a går op b"
let R = fun (a,b) -> b % a = 0 ;;

let aRb' = relation A R B ;;
printfn "%b" (aRb = aRb') ;;

// Relationen "b går op a"
let bRa = relation B R A ;;
printfn "%A" bRa ;;

// Domain Dom(R)
let dom xs =
    xs |> (List.map fst >> List.distinct)
;;
dom aRb ;;

// Identisk med ovenstående:
let dom' xs =
    xs |> List.map fst |> List.distinct
;;
dom' aRb ;;

// Range Ran(R)
let ran xs =
    xs |> (List.map snd >> List.distinct)
;;
ran aRb ;;

// Union(A, B) er foreningsmængden
let union xs ys =
     Set.union (Set.ofList xs) (Set.ofList ys) |> Set.toList
;;
union aRb bRa ;;

// Intersect(A, B) er fællesmængden
let intersect xs ys =
     Set.intersect (Set.ofList xs) (Set.ofList ys) |> Set.toList
;;
intersect aRb bRa ;;

// end
