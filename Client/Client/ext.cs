using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class ext
    {
        public static string[] Split(this string str, string splitter)
        {
            return str.Split(new string[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
