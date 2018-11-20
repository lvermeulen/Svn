namespace SvnCommander
{
    public class SvnCommanderOptions
    {
        public string Command { get; set; }
        public string Argument { get; set; }
        public string PathToSvnExe { get; set; }
        public string WorkingDirectory { get; set; }
        public string OutputKind { get; set; }
        public string OutputName { get; set; }
    }
}
