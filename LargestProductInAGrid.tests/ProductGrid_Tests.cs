﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LargestProductInAGrid.tests
{
    [TestClass]
    public class ProductGrid_Tests
    {
        [TestMethod]
        public void TestOriginalQuestion()
        {
            StreamReader sr = new StreamReader("TestData.txt");
            string data = sr.ReadToEnd();

            ProductGrid pg = new ProductGrid(4, data);
            var max = pg.FindMaxProduct();

            Console.WriteLine(string.Format("Max product is {0} at index {1}", max.Item2, max.Item1));
        }
    }
}
