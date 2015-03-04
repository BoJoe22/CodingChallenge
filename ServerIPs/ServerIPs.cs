using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ServerIPs
{
    public class ServerIPs
    {
        // Using a combination of List and Dictionary to take advantage of each's performance advantages
        private List<string> ips = new List<string>();
        private Dictionary<string, int> ipDict = new Dictionary<string, int>();

        /// <summary>
        /// Add new server IP at O(3) constant time
        /// </summary>
        public bool add(string ipToAdd)
        {
            IPAddress tempIp;
            if (!IPAddress.TryParse(ipToAdd, out tempIp)) return false; // Check for valid IP

            ips.Add(ipToAdd);
            ipDict.Add(ipToAdd, ipDict.Count);

            return true;
        }

        /// <summary>
        /// Newer O(5) constant time remove method
        /// </summary>
        public bool remove(string ipToRemove)
        {
            if (!ipDict.ContainsKey(ipToRemove)) return false;

            int rmIndex = ipDict[ipToRemove];

            ips[rmIndex] = ips.Last();   // Swap IP to remove with last item in Last
            ips.RemoveAt(ips.Count - 1); // This makes for effective removal without having to
                                         // shuffle indexes in the Dictionary

            return ipDict.Remove(ipToRemove);
        }

        /// <summary>
        /// Original O(n) linear complexity remove method
        /// </summary>
        public bool removeOrig(string ipToRemove)
        {
            return ips.Remove(ipToRemove);
        }

        /// <summary>
        /// Get random server IP at O(3) constant time
        /// </summary>
        public string getRandomServer()
        {
            Random random = new Random();
            int randomIndex = random.Next(ips.Count - 1);
            return ips[randomIndex];
        }

        public int getIpListSize() // helper method for tests
        {
            return ips.Count;
        }

        public bool contains(string ipToFind) // helper method for tests
        {
            return ips.Contains(ipToFind);
        }
    }
}
