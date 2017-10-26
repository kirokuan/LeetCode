using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode
{
    class WordBreakClass
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (wordDict.Contains(s)) return true;
            foreach (var key in wordDict.Where(t=>s.StartsWith(t)))
            {
                if (WordBreak(s.Substring(key.Length), wordDict)) {
                    return true;
                }
            }
            return false;
        }
        public bool WordBreakDp(string s, IList<string> wordDict)
        {
            var m = new bool[s.Length+1];
            m[0] = true;
            for (int i = 0; i < s.Length+1; i++)
            {
                var x = s.Substring(0, i);
                foreach (var item in wordDict.Where(t=>x.EndsWith(t)))
                {
                    m[i] = m[i] || m[i - item.Length]; 
                }
            }
            return m[s.Length];
        }
    }
    public class WordBreakTest
    {
        //"abcd"
        [Fact]
        public void test()
        {
            Assert.Equal(true, new WordBreakClass().WordBreak("abcd",new List<string>() { "a", "abc", "b", "cd" }));
        }
        [Fact]
        public void testDp()
        {
            Assert.Equal(true, new WordBreakClass().WordBreakDp("abcd", new List<string>() { "a", "abc", "b", "cd" }));
        }
    }
}