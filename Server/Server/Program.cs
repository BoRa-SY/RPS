using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Statics.Init();
            GameHandler.Init();

            await Task.Delay(-1);
        }
    }
}
