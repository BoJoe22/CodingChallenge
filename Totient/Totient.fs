namespace CodeChallenge

module Totient =
    // Begin brute force functions //
    let rec greatestCommonDenominator x y =
        if y = 0 then x
        else greatestCommonDenominator y (x % y)

    let Phi n =
        let RelativelyPrime n2 =
            seq {
                yield 1
                for i in [2 .. n2] do
                    if greatestCommonDenominator n2 i = 1 then yield i
            }
        RelativelyPrime n |> Seq.length
    
    let NoverPhi n =
        double n / (double (Phi n))

    let MaxNoverPhi n =
        [1 .. n]
        |> List.map(fun x -> NoverPhi x)
        |> List.max
    // End brute force functions //

    /// <summary>
    /// More straightforward way of calculating Phi
    /// </summary>
    let MaxPhi n =
        // Sieve of Eratosthenes
        let rec sieve = function
            | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
            | [] -> []
        let primes = sieve [2..1000] // use Sieve of Eratosthenes to calculate primes in a range

        // Keep multiplying primes until we hit the max limit
        let rec calculate (acc:int, primesList:int list, max:int) =
            let next = acc * primesList.Head
            if next > max then acc
            else calculate (next, primesList.Tail, max)

        calculate (1, primes, n)
        |> NoverPhi