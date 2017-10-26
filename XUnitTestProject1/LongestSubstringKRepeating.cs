
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    class LongestSubstringKRepeating
    {
        public int LongestSubstring(string s, int k)
        {
            var dict=s.GroupBy(t => t).ToDictionary(t => t.Key, c => c.Count())
                .Where(t=>t.Value<k).Select(t=>t.Key)
                ;
            var strs = new List<string>() { s};
            foreach (var token in dict)
            {
                strs = strs.SelectMany(t => t.Split(token).ToList()).ToList();
            }
            return strs.Max(x=>x.Length);
        }
    }
    public class LSKRTest
    {

        [Theory]
        [InlineData("aaabb", 3, 3)]
        [InlineData("ababacb", 3, 5)]
        public void test2(string a, int k, int answer)
        {
            Assert.Equal(answer, new LongestSubstringKRepeating().LongestSubstring(a,k));

        }
    }
}
