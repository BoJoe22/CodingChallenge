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
                if i = productLength then acc
                else productAcc(index, i+1, gridFunction(index, i) * acc)
            productAcc(index, 0, 1)

//        let LRresult = product(10, fun (ind, i) -> grid.[ind + width * i + i])
//        let RLresult = product(10, fun (ind, i) -> grid.[ind + width * i - i])
//        let HorResult = product(10, fun (ind, i) -> grid.[ind + i])
//        let VerResult = product(10, fun (ind, i) -> grid.[ind + width * i])

        let verticalStop = grid.Length - width * productLength

        [| grid |> Array.filter(fun x -> x < verticalStop && x % width < width - (productLength - 1)) |> Array.mapi(fun i x -> product(i, fun (gridIndex, itemIndex) -> grid.[gridIndex + width * itemIndex + itemIndex])) |> Array.max;
           grid |> Array.filter(fun x -> x < verticalStop && x % width > (productLength - 1)) |> Array.mapi(fun i x -> product(i, fun (gridIndex, itemIndex) -> grid.[gridIndex + width * itemIndex - itemIndex])) |> Array.max;
           grid |> Array.filter(fun x -> x % width < width - (productLength - 1)) |> Array.mapi(fun i x -> product(i, fun (gridIndex, itemIndex) -> grid.[gridIndex + itemIndex])) |> Array.max;
           grid |> Array.filter(fun x -> x < verticalStop) |> Array.mapi(fun i x -> product(i, fun (gridIndex, itemIndex) -> grid.[gridIndex + width * itemIndex])) |> Array.max |] |> Array.max

//        maxLR grid
//        result()

//
//        let productOfLeftToRightDiagonal index =
//            let verticalStop = grid.Length - width * productLength
//            let rec prodLtoRDiagAcc(index, i, acc) =
//                if i = productLength then acc
//                else prodLtoRDiagAcc(index, i+1, grid.[index + width * i + i] * acc)
//            prodLtoRDiagAcc(index, 0, 1)
//
//        let productOfRightToLeftDiagonal index =
//            let rec prodRtoLDiagAcc(index, i, acc) =
//                if i = productLength then acc
//                else prodRtoLDiagAcc(index, i+1, grid.[index + width * i - i] * acc)
//            prodRtoLDiagAcc(index, 0, 1)
//
//        let productOfHorizontal index =
//            let rec prodHor(index, i, acc) =
//                if i = productLength then acc
//                else prodHor(index, i+1, grid.[index + i] * acc)
//            prodHor(index, 0, 1)
//
//        let productOfVertical index =
//            let rec prodVer(index, i, acc) =
//                if i = productLength then acc
//                else prodVer(index, i+1, grid.[index + width * i] * acc)
//            prodVer(index, 0, 1)
//
//        1
