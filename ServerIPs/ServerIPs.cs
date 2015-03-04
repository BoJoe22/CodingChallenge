﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerIPs
{
    public class ServerIPs
    {
        private List<string> ips = new List<string>();
        private Dictionary<string, int> ipDict = new Dictionary<string, int>();

        public bool Add(string ip)
        {
            IPAddress tempIp;
            if (!IPAddress.TryParse(ip, out tempIp)) return false;

            ips.Add(ip);
            ipDict.Add(ip, ipDict.Count);
            return true;
        }

        public bool remove(string ip)
        {
            if (!ipDict.ContainsKey(ip)) return false;

            int rmIndex = ipDict[ip];

            ips[rmIndex] = ips.Last();
            ips.RemoveAt(ips.Count - 1);

            return ipDict.Remove(ip);
        }

        public bool removeOrig(string ip)
        {
            return ips.Remove(ip);
        }

        public string getRandomServer()
        {
            Random random = new Random();
            int randomIndex = random.Next(ips.Count - 1);
            return ips[randomIndex];
        }

        public int getIpListSize()
        {
            return ips.Count;
        }
    }
}
