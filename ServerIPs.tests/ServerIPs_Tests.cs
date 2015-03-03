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

            string newIp;
            while (ipList.Count < IP_LIST_SIZE)
            {
                newIp = getRandomIp();
                if (!ipList.Exists(ip => ip == newIp))
                    ipList.Add(newIp);
            }
        }

        [TestMethod]
        public void Add()
        {
            foreach (string ip in ipList) { ipManager.Add(ip); }

            int startTime = DateTime.Now.Millisecond;

            ipManager.Add(getRandomIp());

            int endTime = DateTime.Now.Millisecond;

            Console.WriteLine(string.Format("The Add function took {0} milliseconds to complete.", endTime - startTime));

            Assert.AreEqual(IP_LIST_SIZE + 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void RemoveLastIP()
        {
            string ipToRemove = ipList[ipList.Count - 1];
            foreach (string ip in ipList) { ipManager.Add(ip); }

            int startTime = DateTime.Now.Millisecond;

            bool result = ipManager.remove(ipToRemove);

            int endTime = DateTime.Now.Millisecond;

            Console.WriteLine(string.Format("The Remove function took {0} milliseconds to complete.", endTime - startTime));

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void RemoveLastIP_orig()
        {
            string ipToRemove = ipList[ipList.Count - 1];
            foreach (string ip in ipList) { ipManager.Add(ip); }

            int startTime = DateTime.Now.Millisecond;

            bool result = ipManager.removeOrig(ipToRemove);

            int endTime = DateTime.Now.Millisecond;

            Console.WriteLine(string.Format("The Remove function took {0} milliseconds to complete.", endTime - startTime));

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void RemoveRandomIpFromList()
        {
            string ipToRemove = ipList[random.Next(ipList.Count - 1)];

            foreach (string ip in ipList) { ipManager.Add(ip); }

            int startTime = DateTime.Now.Millisecond;

            bool result = ipManager.remove(ipToRemove);

            int endTime = DateTime.Now.Millisecond;

            Console.WriteLine(string.Format("The Remove function took {0} milliseconds to complete.", endTime - startTime));

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void RemoveRandomIpFromList_orig()
        {
            string ipToRemove = ipList[random.Next(ipList.Count - 1)];

            foreach (string ip in ipList) { ipManager.Add(ip); }

            int startTime = DateTime.Now.Millisecond;

            bool result = ipManager.removeOrig(ipToRemove);

            int endTime = DateTime.Now.Millisecond;

            Console.WriteLine(string.Format("The Remove function took {0} milliseconds to complete.", endTime - startTime));

            Assert.IsTrue(result);
            Assert.AreEqual(IP_LIST_SIZE - 1, ipManager.getIpListSize());
        }

        [TestMethod]
        public void getRandomServer()
        {
            foreach (string ip in ipList) { ipManager.Add(ip); }

            int startTime = DateTime.Now.Millisecond;

            string result = ipManager.getRandomServer();

            int endTime = DateTime.Now.Millisecond;

            Console.WriteLine(string.Format("The getRandomServer function took {0} milliseconds to complete.", endTime - startTime));

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, "");
        }
    }
}
