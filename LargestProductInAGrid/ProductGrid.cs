using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestProductInAGrid
{
    public class ProductGrid
    {
        public int Width { get; set; } // of grid
        public int Height { get; set; } // of grid
        public int ProductLength { get; set; } // length of series of numbers to get a product for

        public int[] Grid { get; set; } // grid represented as an array of numbers

        public ProductGrid(int productLength, string gridInput)
        {
            ProductLength = productLength;
            List<int> gridList = new List<int>();

            var rows = gridInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Height = rows.Length;

            Width = rows.First().Split(new char[] { ' ' }).Length;

            foreach (var row in rows)
            {
                var temp = row.Split(new char[] { ' ' });
                gridList.AddRange(temp.Select(x => Int32.Parse(x)));
            }

            Grid = gridList.ToArray();
        }

        public Tuple<int, int> FindMaxProduct()
        {
            Dictionary<int, int> lToRdiag = ProductOfLeftToRightDiagonals();
            int maxLRValue = lToRdiag.Values.Max();
            int maxLRIndex = lToRdiag.First(x => x.Value == maxLRValue).Key;
            var LRDiagResult = new Tuple<int, int>(maxLRIndex, maxLRValue);

            Dictionary<int, int> rToLdiag = ProductOfRightToLeftDiagonals();
            int maxRLValue = rToLdiag.Values.Max();
            int maxRLIndex = rToLdiag.First(x => x.Value == maxRLValue).Key;
            var RLDiagResult = new Tuple<int, int>(maxRLIndex, maxRLValue);

            Dictionary<int, int> horizontal = ProductOfHorizontals();
            int maxHValue = horizontal.Values.Max();
            int maxHIndex = horizontal.First(x => x.Value == maxHValue).Key;
            var HorizontalResult = new Tuple<int, int>(maxHIndex, maxHValue);

            Dictionary<int, int> vertical = ProductOfVerticals();
            int maxVValue = vertical.Values.Max();
            int maxVIndex = vertical.First(x => x.Value == maxVValue).Key;
            var VerticalResult = new Tuple<int, int>(maxVIndex, maxVValue);

            if (LRDiagResult.Item2 >= RLDiagResult.Item2 &&
                LRDiagResult.Item2 >= HorizontalResult.Item2 &&
                LRDiagResult.Item2 >= VerticalResult.Item2)
                return LRDiagResult;

            else if (RLDiagResult.Item2 >= LRDiagResult.Item2 &&
                RLDiagResult.Item2 >= HorizontalResult.Item2 &&
                RLDiagResult.Item2 >= VerticalResult.Item2)
                return RLDiagResult;

            else if (HorizontalResult.Item2 >= LRDiagResult.Item2 &&
                HorizontalResult.Item2 >= RLDiagResult.Item2 &&
                HorizontalResult.Item2 >= VerticalResult.Item2)
                return HorizontalResult;

            else return VerticalResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Dictionary mapping the index of the top left number in the Left to Right Diagonals to the product of the grouping</returns>
        public Dictionary<int, int> ProductOfLeftToRightDiagonals()
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            int verticalMax = Grid.Length - Width * ProductLength;
            for (int i = 0; i < verticalMax; i++)
            {
                if (i % Width < (Width - (ProductLength - 1)))
                {
                    results.Add(i, Grid[i] * Grid[i + Width + 1] * Grid[i + (Width * 2) + 2] * Grid[i + (Width * 3) + 3]);
                }
            }

            return results;
        }

        public Dictionary<int, int> ProductOfRightToLeftDiagonals()
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            int verticalMax = Grid.Length - Width * ProductLength;
            for (int i = 0; i < verticalMax; i++)
            {
                if (i % Width > (ProductLength - 1))
                {
                    results.Add(i, Grid[i] * Grid[i + Width - 1] * Grid[i + (Width * 2) - 2] * Grid[i + (Width * 3) - 3]);
                }
            }

            return results;
        }

        public Dictionary<int, int> ProductOfHorizontals()
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            for (int i = 0; i < Grid.Length; i++)
            {
                if (i % Width < Width - (ProductLength - 1))
                {
                    results.Add(i, Grid[i] * Grid[i + 1] * Grid[i + 2] * Grid[i + 3]);
                }
            }

            return results;
        }

        public Dictionary<int, int> ProductOfVerticals()
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            int verticalMax = Grid.Length - Width * ProductLength;
            for (int i = 0; i < verticalMax; i++)
            {
                results.Add(i, Grid[i] * Grid[i + Width] * Grid[i + (Width * 2)] * Grid[i + (Width * 3)]);
            }

            return results;
        }
    }
}
