namespace Svn.Outputters
{
    public interface IOutputter
    {
        string Output(string output, string name = null);
    }
}
