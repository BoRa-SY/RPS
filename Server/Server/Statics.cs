using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Server
{
    public static class Statics
    {
        public static Random rnd;
        public static void Init()
        {
            rnd = new Random();
            string[] lines = File.ReadAllLines("config.txt");
            IPPort.IP = lines[0];
            IPPort.port = int.Parse(lines[1]);
        }

        public static class IPPort
        {
            public static string IP;
            public static int port;
        }
    }
}
