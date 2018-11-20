namespace Svn.Outputters
{
    public class NoOutputter : IOutputter
    {
        public string Output(string output, string name = null)
        {
            return output;
        }
    }
}
