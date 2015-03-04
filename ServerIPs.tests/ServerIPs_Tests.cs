using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerIPs.tests
{
    [TestClass]
    public class ServerIPs_Tests
    {
        private static Random random = new Random();
        public string getRandomIp()
        {
            return string.Format("{0}.{1}.{2}.{3}", random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        public const int IP_LIST_SIZE = 2000000;
        public HashSet<string> ipList = new HashSet<string>(); // Using HashSet enforces uniqueness without having to do a find
        public ServerIPs ipManager;

        [TestInitialize]
        public void TestsInitialize() // Test initializer that gets called before each test method
        {
            ipManager = new ServerIPs();

            while (ipList.Count < IP_LIST_SIZE)
            {
                ipList.Add(getRandomIp());
            }

            foreach (string ip in ipList) { ipManager.add(ip); } // Add IPs to the IP Manager instance
        }

        [TestMethod]
        public void Add()
        {
            string ipToAdd = getRandomIp();

            bool result = ipManager.add(ipToAdd);

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE + 1, ipManager.getIpListSize());
            Assert.IsTrue(ipManager.contains(ipToAdd));
        }

        [TestMethod]
        public void RemoveLastIP()
        {
            string ipToRemove = ipList.Last();

            bool result = ipManager.remove(ipToRemove);

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
            Assert.IsFalse(ipManager.contains(ipToRemove));
        }

        [TestMethod]
        public void RemoveLastIP_orig()
        {
            string ipToRemove = ipList.Last();

            bool result = ipManager.removeOrig(ipToRemove);

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
            Assert.IsFalse(ipManager.contains(ipToRemove));
        }

        [TestMethod]
        public void RemoveRandomIpFromList()
        {
            string ipToRemove = ipList.ElementAt(random.Next(ipList.Count - 1));

            bool result = ipManager.remove(ipToRemove);

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
            Assert.IsFalse(ipManager.contains(ipToRemove));
        }

        [TestMethod]
        public void RemoveRandomIpFromList_orig()
        {
            string ipToRemove = ipList.ElementAt(random.Next(ipList.Count - 1));

            bool result = ipManager.removeOrig(ipToRemove);

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
            Assert.IsFalse(ipManager.contains(ipToRemove));
        }

        [TestMethod]
        public void getRandomServer()
        {
            string result = ipManager.getRandomServer();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, "");
        }
    }
}
