using GitSheller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sfc = new ProjectSourceManager(@"E:\_github\Raspberry-Initial", @"C:\Program Files\Git\bin\git.exe");
            var state = sfc.CheckStatus();
            // var log = sfc.Commit();

            Console.Read();
        }
    }
}
