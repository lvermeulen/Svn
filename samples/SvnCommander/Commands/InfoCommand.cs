using System.Collections.Generic;
using Svn;
using Svn.Outputters;

namespace SvnCommander.Commands
{
    public class InfoCommand : CommandBase
    {
        private static readonly IDictionary<string, string> s_propertyByArgument = new Dictionary<string, string>
        {
            { "path", "Path" },
            { "url", "Url" },
            { "relativeurl", "RelativeUrl" },
            { "repositoryroot", "RepositoryRoot" },
            { "repositoryuuid", "RepositoryUuid" },
            { "revision", "Revision" },
            { "nodekind", "NodeKind" },
            { "lastchangedauthor", "LastChangedAuthor" },
            { "lastchangedrev", "LastChangedRev" },
            { "lastchangeddate", "LastChangedDate" }
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

            new ConsoleOutputter().Output(outputter.Output(propertyValue, options.OutputName));
        }
    }
}
