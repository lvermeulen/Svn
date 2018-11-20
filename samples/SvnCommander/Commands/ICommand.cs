namespace SvnCommander.Commands
{
    public interface ICommand
    {
        void Execute(SvnCommanderOptions options);
    }
}
