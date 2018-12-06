using System.Collections.Generic;
using System.IO;

namespace Svn
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ToLines(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            using (var reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
