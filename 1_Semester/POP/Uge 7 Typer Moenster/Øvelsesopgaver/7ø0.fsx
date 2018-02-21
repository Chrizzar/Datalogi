///
///
///

// *** Øvelsesopgave 7ø.0 ***
(*
let rec insert xs y =
    match xs with
        | xs when xs = [] -> [y]
        | _ ->
            let x = List.head xs
            match y with
                | y when y < x ->
                    y :: xs
                | _ ->
                    x :: insert (List.tail xs) y

let isort xs = List.fold (fun acc x -> insert acc x) [] xs

let xs = [7;55;34;23;5;42;32;34;8]
printfn "%A\n" (isort xs)
*)

// *** Øvelsesopgave 7ø.1 ***
let rec bubble (xs: int list) =
    match xs with
        | xs when xs = [] -> []
        | _ ->
            let x = List.head xs
            let ys = List.tail xs
            match ys with
                | ys when ys = [] -> [x]
                | _ ->
                    let y = List.head ys
                    match y with
                        | x when x < y ->
                            x :: bubble ys
                        | _ ->
                            y :: bubble (x :: List.tail ys)

let bsort xs =
    List.fold (fun acc _ -> bubble acc) xs
