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

        public GitActionResult Commit()
        {
            try
            {
                CheckGit();
                var log = proxy.Commit(project);
                return new GitActionResult(true, log);
            }
            catch (Exception ex)
            {
                return new GitActionResult(false, ex.Message);
            }
        }

        public void Checkout()
        {

        }

        public GitActionResult GetFileLog(string project, string filePath)
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
            if (!Directory.Exists(".git"))
            {
                proxy.Init();
            }
        }
    }
}
