namespace CodeChallenge

module Totient =
    let rec gcd x y =
        if y = 0 then x
        else gcd y (x % y)

    let Phi n =
        let RelativelyPrime n2 =
            seq {
                yield 1
                for i in [2 .. n2] do
                    if gcd n2 i = 1 then yield i
            }
        
        n
        |> RelativelyPrime
        |> Seq.length
    
    let NoverPhi n =
        double n / (double (Phi n))

    let MaxNoverPhi n =
        [1 .. n]
        |> List.map(fun x -> NoverPhi x)
        |> List.max

    let MaxPhi n =
        let rec sieve = function
            | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
            | [] -> []
        let primes = sieve [2..1000]
        let rec calculate (acc:int, prims:int list, max:int) =
            let nextP = acc * prims.Head
            if nextP > max then acc
            else calculate (nextP, prims.Tail, max)

        calculate (1, primes, n)
        |> NoverPhi