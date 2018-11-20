using System;
using Fclp;
using SvnCommander.Commands;

namespace SvnCommander
{
    public static class Program
    {
        private static void DispatchCommand(SvnCommanderOptions options)
        {
            if (options.Command == "info")
            {
                new InfoCommand().Execute(options);
            }
        }

        private static void DisplayUsage()
        {
            Console.WriteLine("SvnCommander\n");
            Console.WriteLine("Usage:");
            Console.WriteLine("\tSvnCommander <command> <params> [output]\n");
            Console.WriteLine("\te.g. SvnCommander --command \"info\" --argument \"revision\" --svn \"C:\\Program Files\\TortoiseSVN\\bin\\svn.exe\" --directory \"C:\\my\\svn\\repo\\folder\" --output \"envvar\" --name \"SvnRevision\"\n");
        }

        private static SvnCommanderOptions ParseCommandLine(string[] args)
        {
            var parser = new FluentCommandLineParser<SvnCommanderOptions>();
            parser.Setup(arg => arg.Command)
                .As('c', "command")
                .SetDefault("info");
            parser.Setup(arg => arg.Argument)
                .As('a', "argument")
                .SetDefault("revision");
            parser.Setup(arg => arg.PathToSvnExe)
                .As('s', "svn")
                .SetDefault(@"C:\Program Files\TortoiseSVN\bin\svn.exe");
            parser.Setup(arg => arg.WorkingDirectory)
                .As('d', "directory")
                .SetDefault(Environment.CurrentDirectory);
            parser.Setup(arg => arg.OutputKind)
                .As('o', "output")
                .SetDefault("none");
            parser.Setup(arg => arg.OutputName)
                .As('n', "name")
                .SetDefault(null);

            var parseResult = parser.Parse(args);
            if (parseResult.HasErrors)
            {
                DisplayUsage();
                Environment.Exit(1);
            }

            return parser.Object;
        }

        public static void Main(string[] args)
        {
            var options = ParseCommandLine(args);
            DispatchCommand(options);

#if DEBUG
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
#endif
        }
    }
}
