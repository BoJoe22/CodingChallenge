using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseHash.tests
{
    [TestClass]
    public class Analyzer_Tests
    {
        [TestMethod]
        public void test_findString_leepadg()
        {
            var result = String.Concat(Analyzer.findString(680131659347));

            Assert.AreEqual("leepadg", result);
        }

        [TestMethod]
        public void test_findString_originalQuestion_spartan()
        {
            var result = Analyzer.findString(696005871397);

            Assert.AreEqual("spartan", result);
        }

        [TestMethod]
        public void test_countPermutations()
        {
            var count = Analyzer.countPermutations;

            Assert.AreEqual(57657600, count);
        }

        [TestMethod]
        public void test_getPermsWithRep()
        {
            //var count = Analyzer.countPermutations2;

            //Console.WriteLine(string.Format("Number of permutations is {0}", count));
            //Assert.AreEqual(57657600, count);
        }
    }
}
