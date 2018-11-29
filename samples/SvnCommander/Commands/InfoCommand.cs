using System.Collections.Generic;
using Svn;
using Svn.Outputters;

namespace SvnCommander.Commands
{
    public class InfoCommand : CommandBase
    {
        private static readonly IDictionary<string, string> s_propertyByArgument = new Dictionary<string, string>
        {
            { "path", nameof(SvnInfo.Path) },
            { "url", nameof(SvnInfo.Url) },
            { "relativeurl", nameof(SvnInfo.RelativeUrl) },
            { "repositoryroot", nameof(SvnInfo.RepositoryRoot) },
            { "repositoryuuid", nameof(SvnInfo.RepositoryUuid) },
            { "revision", nameof(SvnInfo.Revision) },
            { "nodekind", nameof(SvnInfo.NodeKind) },
            { "lastchangedauthor", nameof(SvnInfo.LastChangedAuthor) },
            { "lastchangedrev", nameof(SvnInfo.LastChangedRev) },
            { "lastchangeddate", nameof(SvnInfo.LastChangedDate) },
            { "schedule", nameof(SvnInfo.Schedule) },
            { "locktoken", nameof(SvnInfo.LockToken) },
            { "lockowner", nameof(SvnInfo.LockOwner) },
            { "lockcreated", nameof(SvnInfo.LockCreated) }
        };

        private string GetPropertyValue(object obj, string propertyName) => obj
            .GetType()
            .GetProperty(propertyName)
            .GetValue(obj)
            .ToString();

        public override void Execute(SvnCommanderOptions options)
        {
            var outputter = GetOutputter(options.OutputKind);
            var svnInfo = new SvnInfo(options.PathToSvnExe, options.WorkingDirectory);
            string propertyName = s_propertyByArgument[options.Argument.ToLowerInvariant()];
            string propertyValue = GetPropertyValue(svnInfo, propertyName);

            if (outputter.GetType() != typeof(ConsoleOutputter))
            {
                new ConsoleOutputter().Output(outputter.Output(propertyValue, options.OutputName));
            }
        }
    }
}
