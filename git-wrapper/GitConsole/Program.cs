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
            var sfc = new ProjectSourceManager(@"C:\me\gits\ConfigMate", @"C:\Program Files\Git\bin\git.exe");
            var log = sfc.GetProjectLog();
            GitFormatter.FormatHistory(log.Message);
            // var log = sfc.Commit();

            Console.Read();
        }
    }
}
