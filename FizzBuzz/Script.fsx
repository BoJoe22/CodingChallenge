// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.


// Define your library scripting code here

[1..100]
|> Seq.map (function
| x when x%5=0 && x%3=0 -> "FizzBuzz"
| x when x%3=0 -> "Fizz"
| x when x%5=0 -> "Buzz"
| x -> string x)
|> Seq.iter (printfn "%s")