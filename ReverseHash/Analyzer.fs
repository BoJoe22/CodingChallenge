namespace ReverseHash

module Analyzer =
    let letters = [| 'a'; 'c'; 'd'; 'e'; 'g'; 'i'; 'l'; 'm'; 'n'; 'o'; 'p'; 'r'; 's'; 't'; 'u'; 'w' |]

    let hash (s:string) =
        Array.fold(fun acc letter -> acc * 37 + (Array.findIndex(fun l -> letter = l) letters)) 7 (s.ToCharArray()) 
//        let rec hashAcc (acc, i, stop) =
//            if i = stop then acc
//            else hashAcc(acc * 37 + Array.findIndex(s.[i]), )
//        for i in 0..s.Length do
            
    let rec combinations acc size set = seq {
        match size, set with
        | n, x::xs ->
            if n > 0 then yield! combinations (x::acc) (n - 1) xs
            if n >= 0 then yield! combinations acc n xs
        | 0, [] -> yield acc
        | _, [] -> () }

    let permutations = combinations [] 7 (Array.toList letters)

    let findString hashToFind =
        permutations
        |> Seq.find(fun x -> hash(String.concat("") (List.toSeq x)) = hashToFind)