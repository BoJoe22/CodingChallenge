using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerIPs
{
    public class ServerIPs
    {
        private List<string> ips = new List<string>();

        public bool Add(string ip)
        {
            try
            {
                ips.Add(ip);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool remove(string ip)
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
