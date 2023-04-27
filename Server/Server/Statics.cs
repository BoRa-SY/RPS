using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Statics
    {
        public static Random rnd;
        public static void Init()
        {
            rnd = new Random();
        }
    }
}
