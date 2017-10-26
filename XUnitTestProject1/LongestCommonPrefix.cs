using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    class LongestCommonPrefixClass
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return string.Empty;
            var strsList = strs.ToList();
            for (var i = 0; i < strs[0].Length; i++)
            {
                if (!strsList.Select(s => s.StartsWith(strs[0].Substring(0, i + 1)))
                    .Aggregate((pre, next) => pre && next))
                {
                    if (i == 0) return "";
                    return strs[0].Substring(0, i);
                }

            }
            return strs[0];
        }

        public static string ReverseWords(string s)
        {
            var sb = new StringBuilder();
            s.Split(' ').Select(t => new string(t.ToCharArray().Reverse().ToArray()))
                .ToList().ForEach(t=>sb.Append(t+" "));
            return sb.ToString().TrimEnd();
        }
    }
}
