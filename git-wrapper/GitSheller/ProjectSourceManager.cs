using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSheller
{
    public class ProjectSourceManager
    {
        private string project;
        private string git;
        private GitProxy proxy;

        public ProjectSourceManager(string project, string git)
        {
            this.project = project;
            this.git = git;
            proxy = new GitProxy(git); 
        }

        public void Compare()
        {

        }

        public void ViewFile()
        {

        }

        public GitActionResult CommitChange(string comments)
        {
            try
            {
                CheckGit();
                var msg = proxy.Add(project);
                Console.WriteLine(msg);
                msg = proxy.Commit(project, comments);
                Console.WriteLine(msg);
                return new GitActionResult(true, msg);
            }
            catch (Exception ex)
            {
                return new GitActionResult(false, ex.Message);
            }
        }

        public void Checkout()
        {

        }

        public GitActionResult GetFileLog(string filePath)
        {
            try
            {
                CheckGit();
                var log = proxy.GetFileLog(project, filePath);
                return new GitActionResult(true, log);
            }
            catch (Exception ex)
            {
                return new GitActionResult(false, ex.Message);
            }
        }

        public GitActionResult GetProjectLog()
        {
            try
            {
                CheckGit();
                var log = proxy.GetProjectLog(project);
                return new GitActionResult(true, log);
            }
            catch (Exception ex)
            {
                return new GitActionResult(false, ex.Message);
            }
        }

        protected void CheckGit()
        {
            if (!Directory.Exists(Path.Combine(project, ".git")))
            {
                proxy.Init();
            }
        }

        /// <summary>
        /// If there is change, return false
        /// </summary>
        /// <returns></returns>
        public bool CheckStatus()
        {
            try
            {
                CheckGit();
                var log = proxy.GetStatus(project);
                return GitMessageParser.ParseStatus(log);
            }
            catch
            {
                return true;
            }
        }
    }
}
