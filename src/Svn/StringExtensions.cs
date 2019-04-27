using System.Collections.Generic;
using System.IO;

namespace Svn
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ToLines(this string s)
        {
            if (s == null)
            {
                yield break;
            }

            using (var reader = new StringReader(s))
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
