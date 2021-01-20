using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSheller
{
    public class GitActionResult
    {
        public static GitActionResult Success()
        {
            return new GitActionResult(true);
        }

        public bool IsSuccess { get; }

        public string Message { get; }

        public GitActionResult(bool success, string message = "")
        {
            IsSuccess = success;
            Message = message;
        }
    }
}
