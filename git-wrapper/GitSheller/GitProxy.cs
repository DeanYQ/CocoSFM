using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSheller
{
    public class GitProxy
    {
        private string path;

        public GitProxy(string path)
        {
            this.path = path;
        }

        public void Init()
        {
            Run("init");
        }

        public string Add(string projectPath)
        {
            return Run($"--path {projectPath} add .");
        }

        public string Commit(string projectPath, string comments)
        {
            return Run($"--path {projectPath} commit -m {comments}");
        }

        public void Checkout()
        {
        }

        public string GetStatus(string projectPath)
        {
            return Run($@"--git-dir={projectPath}\.git --work-tree={projectPath} status");
        }

        public string GetFileLog(string projectPath, string filePath)
        {

            return Run($@"--git-dir={projectPath}\.git log -- {filePath}");
        }

        public string GetProjectLog(string projectPath)
        {
            return Run($@"--git-dir={projectPath}\.git log");
        }

        private string Run(string arguments)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = this.path;
            startInfo.Arguments = arguments;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            var message = process.StandardOutput.ReadToEnd();
            process.StandardOutput.Close();
            process.Close();
            return message;
        }
    }
}
