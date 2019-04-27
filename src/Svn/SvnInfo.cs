using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Svn
{
    public class SvnInfo
    {
        private readonly string _pathToSvnExe;
        private readonly string _workingDirectory;

        public string Path { get; set; }
        public string Url { get; set; }
        public string RelativeUrl { get; set; }
        public string RepositoryRoot { get; set; }
        public string RepositoryUuid { get; set; }
        public string Revision { get; set; }
        public string NodeKind { get; set; }
        public string LastChangedAuthor { get; set; }
        public string LastChangedRev { get; set; }
        public string LastChangedDate { get; set; }
        public string Schedule { get; set; }
        public string LockToken { get; set; }
        public string LockOwner { get; set; }
        public string LockCreated { get; set; }

        public SvnInfo(string pathToSvnExe, string workingDirectory)
        {
            _pathToSvnExe = pathToSvnExe;
            _workingDirectory = workingDirectory;

            GetInfo();
        }

        private string GetPropertyNameFromExpression<T>(Expression<Func<T, string>> propertyExpression) =>
            propertyExpression.Body is MemberExpression memberExpression && memberExpression.Member.MemberType == MemberTypes.Property
                ? memberExpression.Member.Name
                : null;

        private void SetPropertyValueAfterLineSubString(string line, Expression<Func<SvnInfo, string>> expression, string path)
        {
            if (!line.StartsWith(path, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            string value = line.Substring(path.Length);
            string propertyName = GetPropertyNameFromExpression(expression);
            if (propertyName == null)
            {
                return;
            }

            typeof(SvnInfo).GetProperty(propertyName)?.SetValue(this, value);
        }

        private void ParseOutput(string output)
        {
            foreach (string line in output.ToLines())
            {
                SetPropertyValueAfterLineSubString(line, x => x.Path, "Path: ");
                SetPropertyValueAfterLineSubString(line, x => x.Url, "URL: ");
                SetPropertyValueAfterLineSubString(line, x => x.RelativeUrl, "Relative URL: ");
                SetPropertyValueAfterLineSubString(line, x => x.RepositoryRoot, "Repository Root: ");
                SetPropertyValueAfterLineSubString(line, x => x.RepositoryUuid, "Repository UUID: ");
                SetPropertyValueAfterLineSubString(line, x => x.Revision, "Revision: ");
                SetPropertyValueAfterLineSubString(line, x => x.NodeKind, "Node Kind: ");
                SetPropertyValueAfterLineSubString(line, x => x.LastChangedAuthor, "Last Changed Author: ");
                SetPropertyValueAfterLineSubString(line, x => x.LastChangedRev, "Last Changed Rev: ");
                SetPropertyValueAfterLineSubString(line, x => x.LastChangedDate, "Last Changed Date: ");
                SetPropertyValueAfterLineSubString(line, x => x.Schedule, "Schedule: ");
                SetPropertyValueAfterLineSubString(line, x => x.LockToken, "Lock Token: ");
                SetPropertyValueAfterLineSubString(line, x => x.LockOwner, "Lock Owner: ");
                SetPropertyValueAfterLineSubString(line, x => x.LockCreated, "Lock Created: ");
            }
        }

        private string ExecuteProgram(string fileName, string arguments)
        {
            var startInfo = new ProcessStartInfo {
                FileName = fileName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = arguments,
                WorkingDirectory = _workingDirectory,
                CreateNoWindow = true
            };
            var process = Process.Start(startInfo);
            string standardOutput = process?.StandardOutput.ReadToEnd();
            process?.WaitForExit();

            if (process == null || string.IsNullOrEmpty(standardOutput))
            {
                throw new InvalidOperationException(process?.StandardError.ReadToEnd());
            }

            return standardOutput;
        }

        private void GetInfo()
        {
            string output = ExecuteProgram(_pathToSvnExe, "info");
            ParseOutput(output);
        }
    }
}
