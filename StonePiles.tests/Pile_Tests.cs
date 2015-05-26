using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StonePiles;

namespace StonePiles.tests
{
    [TestClass]
    public class Pile_Tests
    {
        [TestMethod]
        public void Test_GetPileTree()
        {
            PileTree tree = new PileTree(5);
            var result = tree.GetPileTree(5);
        }

        [TestMethod]
        public void Test_GetPileCombinations()
        {
            PileTree tree = new PileTree(5);

            var result = tree.GetPileCombinations(3);

            Assert.AreEqual(1, result.Count);
        }
    }
}
