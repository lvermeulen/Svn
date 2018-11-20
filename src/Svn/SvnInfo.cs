using System;
using System.Diagnostics;

namespace Svn
{
    public class SvnInfo
    {
        private readonly string _pathToSvnExe;
        private readonly string _workingDirectory;
        private readonly string _revision;

        public SvnInfo(string pathToSvnExe, string workingDirectory, string revision = "HEAD")
        {
            _pathToSvnExe = pathToSvnExe;
            _workingDirectory = workingDirectory;
            _revision = revision;

            GetInfo();
        }

        private void GetInfo()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = _pathToSvnExe,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = $"info --revision {_revision}",
                WorkingDirectory = _workingDirectory,
                CreateNoWindow = true
            };
            var process = Process.Start(startInfo);
            string output = process?.StandardOutput.ReadToEnd();
            process?.WaitForExit();

            if (process == null || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException(process?.StandardError.ReadToEnd());
            }

            var lines = output.Split(new [] { "\n", "\r", @"\n\r", @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.StartsWith("Path: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    Path = line.Substring("Path: ".Length);
                    continue;
                }
                if (line.StartsWith("URL: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    Url = line.Substring("URL: ".Length);
                    continue;
                }
                if (line.StartsWith("Relative URL: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    RelativeUrl = line.Substring("Relative URL: ".Length);
                    continue;
                }
                if (line.StartsWith("Repository Root: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    RepositoryRoot = line.Substring("Repository Root: ".Length);
                    continue;
                }
                if (line.StartsWith("Repository UUID: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    RepositoryUuid = line.Substring("Repository UUID: ".Length);
                    continue;
                }
                if (line.StartsWith("Revision: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    Revision = line.Substring("Revision: ".Length);
                    continue;
                }
                if (line.StartsWith("Node Kind: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    NodeKind = line.Substring("Node Kind: ".Length);
                    continue;
                }
                if (line.StartsWith("Last Changed Author: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    LastChangedAuthor = line.Substring("Last Changed Author: ".Length);
                    continue;
                }
                if (line.StartsWith("Last Changed Rev: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    LastChangedRev = line.Substring("Last Changed Rev: ".Length);
                    continue;
                }
                if (line.StartsWith("Last Changed Date: ", StringComparison.InvariantCultureIgnoreCase))
                {
                    LastChangedDate = line.Substring("Last Changed Date: ".Length);
                }
            }
        }

        public string Path { get; private set; }
        public string Url { get; private set; }
        public string RelativeUrl { get; private set; }
        public string RepositoryRoot { get; private set; }
        public string RepositoryUuid { get; private set; }
        public string Revision { get; private set; }
        public string NodeKind { get; private set; }
        public string LastChangedAuthor { get; private set; }
        public string LastChangedRev { get; private set; }
        public string LastChangedDate { get; private set; }
    }
}
