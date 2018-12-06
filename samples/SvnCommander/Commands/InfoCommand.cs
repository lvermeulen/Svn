using System.Collections.Generic;
using Svn;
using Svn.Outputters;

namespace SvnCommander.Commands
{
    public class InfoCommand : CommandBase
    {
        private static readonly IDictionary<string, string> s_propertyByArgument = new Dictionary<string, string>
        {
            { nameof(SvnInfo.Path).ToLower(), nameof(SvnInfo.Path) },
            { nameof(SvnInfo.Url).ToLower(), nameof(SvnInfo.Url) },
            { nameof(SvnInfo.RelativeUrl).ToLower(), nameof(SvnInfo.RelativeUrl) },
            { nameof(SvnInfo.RepositoryRoot).ToLower(), nameof(SvnInfo.RepositoryRoot) },
            { nameof(SvnInfo.RepositoryUuid).ToLower(), nameof(SvnInfo.RepositoryUuid) },
            { nameof(SvnInfo.Revision).ToLower(), nameof(SvnInfo.Revision) },
            { nameof(SvnInfo.NodeKind).ToLower(), nameof(SvnInfo.NodeKind) },
            { nameof(SvnInfo.LastChangedAuthor).ToLower(), nameof(SvnInfo.LastChangedAuthor) },
            { nameof(SvnInfo.LastChangedRev).ToLower(), nameof(SvnInfo.LastChangedRev) },
            { nameof(SvnInfo.LastChangedDate).ToLower(), nameof(SvnInfo.LastChangedDate) },
            { nameof(SvnInfo.Schedule).ToLower(), nameof(SvnInfo.Schedule) },
            { nameof(SvnInfo.LockToken).ToLower(), nameof(SvnInfo.LockToken) },
            { nameof(SvnInfo.LockOwner).ToLower(), nameof(SvnInfo.LockOwner) },
            { nameof(SvnInfo.LockCreated).ToLower(), nameof(SvnInfo.LockCreated) }
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
