using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class GenerateParethesis
    {
        public IList<string> GenerateParenthesis(int n)
        {
            if (n == 1) return new List<string>() { "()" };
            var dict = new Dictionary<int, List<string>>() {
                {1,new List<string>{ "()"} }
            };
            for (int i = 2; i <= n; i++)
            {
                dict[i] = new List<string>();
                //dict[i].Add(new String('(',i)+ new String(')', i));
                dict[i].AddRange(dict[i-1].Select(t=>"("+t+")"));
                for (int j = 1; j < i; j++)
                {
                    dict[i].AddRange(dict[i - j].Select(t => dict[j].Select(k => k + t)).SelectMany(t => t));
                }
                dict[i] = dict[i].Distinct().ToList();
            }
            return dict[n];
        }
    }
}
