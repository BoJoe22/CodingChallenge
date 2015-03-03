using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        public const int IP_LIST_SIZE = 500000;
        public List<string> ipList = new List<string>(IP_LIST_SIZE);
        public ServerIPs ipManager;

        [TestInitialize]
        public void TestsInitialize()
        {
            ipManager = new ServerIPs();

            for (int i = 0; i < IP_LIST_SIZE; i++)
            {
                ipList.Add(getRandomIp());
            }
        }

        [TestMethod]
        public void Add()
        {
            foreach (string ip in ipList) { ipManager.Add(ip); }

            Assert.IsTrue(ipManager.Add(getRandomIp()));
            Assert.AreEqual(IP_LIST_SIZE + 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void Remove()
        {
            string ipToRemove = ipList[ipList.Count - 1];
            foreach (string ip in ipList) { ipManager.Add(ip); }

            bool result = ipManager.remove(ipToRemove);

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void getRandomServer()
        {
            foreach (string ip in ipList) { ipManager.Add(ip); }

            string result = ipManager.getRandomServer();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, "");
        }
    }
}
