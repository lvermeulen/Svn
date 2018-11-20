using System;
using Svn.Outputters;

namespace SvnCommander.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected IOutputter GetOutputter(string outputKind)
        {
            if (outputKind.Equals("none", StringComparison.InvariantCultureIgnoreCase))
            {
                return new NoOutputter();
            }
            if (outputKind.Equals("envvar", StringComparison.InvariantCultureIgnoreCase))
            {
                return new EnvVarOutputter();
            }

            return new ConsoleOutputter();
        }

        public abstract void Execute(SvnCommanderOptions options);
    }
}
