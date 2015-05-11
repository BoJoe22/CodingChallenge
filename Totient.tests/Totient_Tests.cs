using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge;

namespace CodeChallenge.tests
{
    [TestClass]
    public class Totient_Tests
    {
        [TestMethod]
        public void test_gcd()
        {
            var expected = 5;
            var result = Totient.greatestCommonDenominator(1000000, 986455);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void test_Phi_of5is4()
        {
            var expected = 4;
            var result = Totient.Phi(5);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void test_Phi_upTo10()
        {
            var expected = new int[] { 1, 2, 2, 4, 2, 6, 4, 6, 4 };

            var first10 = Enumerable.Range(2, 9).ToArray();
            var phiArray = first10.Select(x => Totient.Phi(x)).ToArray();

            CollectionAssert.AreEquivalent(expected, phiArray);
        }

        [TestMethod]
        public void test_NoverPhi_upTo10()
        {
            var expected = new double[] { 2, 1.5, 2, 1.25, 3, 7.0/6, 2, 1.5, 2.5 };

            var first10 = Enumerable.Range(2, 9).ToArray();
            var nOverPhiArray = first10.Select(x => Totient.NoverPhi(x)).ToArray();

            CollectionAssert.AreEquivalent(expected, nOverPhiArray);
        }

        [TestMethod]
        public void test_MaxNoverPhi_upTo10()
        {
            var expected = 3;
            var result = Totient.MaxNoverPhi(10);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void test_MaxNoverPhi_upTo1000()
        {
            var expected = 4.375;
            var result = Totient.MaxNoverPhi(1000);

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test brute-force calculation
        /// </summary>
        /// <remarks>This takes a really really really long time to calculate</remarks>
        [TestMethod]
        public void test_MaxNoverPhi_upTo1000000()
        {
            var expected = 510510.0 / 92160;
            var result = Totient.MaxNoverPhi(1000000);

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test more effective straight calculation
        /// </summary>
        [TestMethod]
        public void test_MaxPhi_upTo1000000()
        {
            var expected = 510510.0 / 92160;
            var result = Totient.MaxPhi(1000000);
            Console.WriteLine(String.Format("Max N over Phi is {0}", result));

            Assert.AreEqual(expected, result);
        }
    }
}
