namespace LargestProductInAGrid_FSharp

open System

module ProductGrid = 
    let FindMaxProduct(productLength : int, gridInput : string) = 
        let rows = gridInput.Split([| Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries)
        let height = Array.length rows
        let width = rows.[0].Split(' ').Length
        let grid = gridInput.Split([| Environment.NewLine; " " |], StringSplitOptions.RemoveEmptyEntries)
                   |> Array.map (fun eachChar -> Int32.Parse(eachChar))

        let product (index, gridFunction) =
            let rec productAcc(index, i, acc) =
                match i = productLength with
                | true -> acc
                | _ -> productAcc(index, i+1, gridFunction(index, i) * acc)
            productAcc(index, 0, 1)

        let maxOfType (filterF, productFunction) =
            [|0..(width * height) - 1|] |> Array.filter(filterF) |> Array.map(fun index -> product(index, productFunction)) |> Array.max

        let verticalStop = grid.Length - width * productLength

        [| maxOfType((fun x -> x < verticalStop && x % width < width - (productLength - 1)), 
                     (fun (gridIndex, itemIndex) -> grid.[gridIndex + width * itemIndex + itemIndex]));
           maxOfType((fun x -> x < verticalStop && x % width > (productLength - 1)),
                     (fun (gridIndex, itemIndex) -> grid.[gridIndex + width * itemIndex - itemIndex]));
           maxOfType((fun x -> x % width < width - (productLength - 1)),
                     (fun (gridIndex, itemIndex) -> grid.[gridIndex + itemIndex]));
           maxOfType((fun x -> x < verticalStop),
                     (fun (gridIndex, itemIndex) -> grid.[gridIndex + width * itemIndex]));
        |] |> Array.max