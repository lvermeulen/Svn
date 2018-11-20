using System;
using Xunit;

namespace Svn.Outputters.Tests
{
    public class EnvVarOutputterShould
    {
        private readonly IOutputter _outputter = new EnvVarOutputter();

        [Fact]
        public void Output()
        {
            const string NAME = nameof(EnvVarOutputterShould) + nameof(Output);

            _outputter.Output(nameof(EnvVarOutputterShould), NAME);
            Assert.Equal(nameof(EnvVarOutputterShould), Environment.GetEnvironmentVariable(NAME, EnvironmentVariableTarget.Machine));
            Environment.SetEnvironmentVariable(nameof(EnvVarOutputterShould) + nameof(Output), null, EnvironmentVariableTarget.Machine);
        }
    }
}
