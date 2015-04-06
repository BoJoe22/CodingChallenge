namespace ReverseHash

open System

module Analyzer =
    let letters = [| 'a'; 'c'; 'd'; 'e'; 'g'; 'i'; 'l'; 'm'; 'n'; 'o'; 'p'; 'r'; 's'; 't'; 'u'; 'w' |]

    let hash (s) =
        Array.fold(fun acc letter -> acc * int64(37) + int64(Array.findIndex(fun l -> letter = l) letters)) (int64(7)) (s) 
            
    let rec permutationBuilder acc size set = seq {
        match size with
        | 0 -> yield List.toArray acc
        | n -> if n > 0 then for item in letters do yield! permutationBuilder (item::acc) (n - 1) set 
    }

    let findString2 (hashToFind:int64) =
        permutationBuilder [] 7 (letters) |> Seq.find(fun x -> hashToFind = int64(hash(x)))
                                          |> String.Concat
        
    let rec outerProduct = function
        | [] -> Seq.singleton []
        | L::Ls -> L |> Seq.collect (fun x -> outerProduct Ls |> Seq.map(fun L -> x::L))

    let getPermsWithRep n L =
        List.replicate n L |> outerProduct

    let rec combinations acc size set = seq {
        match size, set with
        | n, x::xs ->
            if n > 0 then yield! combinations (x::acc) (n - 1) xs
            if n >= 0 then yield! combinations acc n xs
        | 0, [] -> yield acc
        | _, [] -> () }

    let permutations = permutationBuilder [] 7 (letters)
//    let permutations2 = getPermsWithRep 7 (Array.toList letters)


    let countPermutations = Seq.length permutations
//    let countPermutations2 = getPermsWithRep 7 (Array.toList letters) |> Seq.length

    let findString (hashToFind:int64) =
        permutations |> Seq.find(fun x -> hashToFind = int64(hash(x)))
                     |> String.Concat