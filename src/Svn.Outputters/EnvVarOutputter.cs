using System;

namespace Svn.Outputters
{
    public class EnvVarOutputter : IOutputter
    {
        public string Output(string output, string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Environment.SetEnvironmentVariable(name, output, EnvironmentVariableTarget.Machine);
            return output;
        }
    }
}
