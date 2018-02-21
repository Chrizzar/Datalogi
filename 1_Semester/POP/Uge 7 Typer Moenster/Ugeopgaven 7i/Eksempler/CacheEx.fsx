let init_cache (a:string) (b:string) =
    (fun x -> Array.init b.Length fun x -> -1)
    |> Array.init a.Length

Array.init 10 (fun x -> Array.init 10 fun x -> x)

[0..10] |> list.filter odd

// |> = piping
