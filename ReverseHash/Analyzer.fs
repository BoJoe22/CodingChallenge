namespace ReverseHash

open System

module Analyzer =
    let letters = [| 'a'; 'c'; 'd'; 'e'; 'g'; 'i'; 'l'; 'm'; 'n'; 'o'; 'p'; 'r'; 's'; 't'; 'u'; 'w' |]

    let hash (s) =
//        Array.fold(fun acc letter -> acc * 37 + (Array.findIndex(fun l -> letter = l) letters)) 7 (s) 
        Array.fold(fun acc letter -> acc * int64(37) + int64(Array.findIndex(fun l -> letter = l) letters)) (int64(7)) (s) 
//        let rec hashAcc (acc, i, stop) =
//            if i = stop then acc
//            else hashAcc(acc * 37 + Array.findIndex(s.[i]), )
//        for i in 0..s.Length do
            
    let rec permutationBuilder acc size set = seq {
        match size with
        | 0 -> yield List.toArray acc
        | n ->
            if n > 0 then 
                for item in letters do
                    yield! permutationBuilder (item::acc) (n - 1) set 
//            if n > 0 then yield! permutationBuilder (x::acc) (n - 1) xs 
//            if n >= 0 then yield! permutationBuilder acc n xs  
//        | _ -> ()
    }
        
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

//    let permutations = combinations [] 7 (Array.toList letters)
    let permutations = permutationBuilder [] 7 (letters)

    let countPermutations = Seq.length permutations

//    let countPermutations2 = getPermsWithRep 7 (Array.toList letters) |> Seq.length

    let findString (hashToFind:int64) =
//        let temp = permutations
//        let temp4 = Seq.length temp
//        let temp2 = temp |> Seq.nth 1
//        let temp3 = int64(hash(temp2))
//        let result = temp
//                     |> Seq.find(fun x -> hashToFind = int64(hash(x)))
//                     
//        new String(result)
//        let file = new IO.StreamWriter("C:\\Users\\JosefKoza\\Desktop\\AnalyzerOut.txt")
//        file.WriteLine(String.Format("Looking for {0}", hashToFind))
        let result = permutations |> Seq.find(fun x -> let hashCalculated = int64(hash(x))
//                                                       file.WriteLine(String.Format(" > {0}", hashCalculated))
//                                          Console.WriteLine(String.Format("Looking for {0}. Comparing to {1}", hashCalculated, hashToFind))
                                                       hashToFind = hashCalculated)
        result |> String.Concat