using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    class DNASequences
    {
        const int SubseqLength = 10;
        public static IList<string> FindRepeatedDnaSequences(string s)
        {
            var subsequences = new Dictionary<string, int>();

            for (int i = 0; i <= s.Length - SubseqLength; i ++)
            {
                var subseq = s.Substring(i, SubseqLength);
                if (!subsequences.ContainsKey(subseq))
                {
                    subsequences.Add(subseq, 1);
                }
                else {
                    subsequences[subseq]++;
                }
            }
            return subsequences.Where(c=>c.Value>1).Select(k=>k.Key).ToList();
        }
    }
}
