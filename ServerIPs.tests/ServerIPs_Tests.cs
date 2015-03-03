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

        public List<string> ipList = new List<string>(1000);
        public ServerIPs srvIPs;

        [TestInitialize]
        public void TestsInitialize()
        {
            srvIPs = new ServerIPs();

            for (int i = 0; i < 100000; i++)
            {
                ipList.Add(getRandomIp());
            }
        }

        [TestMethod]
        public void Add()
        {
            Assert.IsTrue(srvIPs.Add(getRandomIp()));
        }

        [TestMethod]
        public void Remove()
        {
            string ipToRemove = ipList[ipList.Count - 1];

            Assert.IsTrue(srvIPs.remove(ipToRemove));
        }

        [TestMethod]
        public void getRandomServer()
        {
            string result = srvIPs.getRandomServer();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, "");
        }
    }
}
