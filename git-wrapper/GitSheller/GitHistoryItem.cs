using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSheller
{
    public class GitHistoryItem
    {
        public string CommitId { get; set; } 

        public string Author { get; set; }

        public string Date { get; set; }

        public string Message { get; set; }

        public GitHistoryItem()
        {
            CommitId = "";
            Author = "";
            Date = "";
            Message = "";
        }
    }
}
