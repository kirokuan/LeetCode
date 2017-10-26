using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var list = t.OrderBy(x=>x).ToList();
            var listS = s.OrderBy(x => x).ToList();
            
            for (int i = 0; i < s.Length; i++)
            {
                if (list[i]!=listS[i]) return false;

            }
            return true;
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //var result = new List<IList<string>>();
            return strs.GroupBy(t =>new string(t.OrderBy(x => x).ToArray()))
                .ToDictionary(u => u.Key, b => b.ToList()).Select(t => (IList < string >)t.Value).ToList();
           // return result;
        }
    }
}
