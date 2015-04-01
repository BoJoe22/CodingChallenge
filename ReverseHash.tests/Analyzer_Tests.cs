using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseHash.tests
{
    [TestClass]
    public class Analyzer_Tests
    {
        [TestMethod]
        public void test_findString()
        {
            var result = Analyzer.findString(680131659347);
            Console.WriteLine(string.Format("Result was \"{0}\""), result);
        }

        [TestMethod]
        public void test_countPermutations()
        {
            var count = Analyzer.countPermutations;
            Console.WriteLine(string.Format("Number of permutations is {0}"), count);

            Assert.AreEqual(57657600, count);
        }

        [TestMethod]
        public void test_getPermsWithRep()
        {
            var count = Analyzer.countPermutations2;

            Console.WriteLine(string.Format("Number of permutations is {0}"), count);
            Assert.AreEqual(57657600, count);
        }
    }
}
