using System;

namespace Svn.Outputters
{
    public class ConsoleOutputter : IOutputter
    {
        public string Output(string output, string name = null)
        {
            Console.WriteLine(output);
            return output;
        }
    }
}
