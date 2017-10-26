using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class LongestSubsequence
    {
        public static int LengthOfLIS(int[] nums)
        {
            var count = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                
                var subseq= count.Where(t => t.Key < nums[i]);
                if (count.ContainsKey(nums[i])) {
                    count[nums[i]] = Math.Max(count[nums[i]], (subseq.Count() > 0) ?
                    subseq.Max(t => t.Value) + 1 : 1);
                }
                else
                count.Add(nums[i], (subseq.Count() > 0)?
                    subseq.Max(t => t.Value) + 1:1);
                
            }
            return count.Count()==0? 0:count.Values.Max();
        }
        
        public static int FindLongestChain(int[,] pairs)
        {
            var list=pairs.Cast<int>()
            .Select((x, i) => new { x, index = i / pairs.Rank })  
            .GroupBy(x => x.index)                                 
            .Select(x => x.Select(s => s.x).ToList())
            .OrderBy(t=>t[0])
            .ToList();
            var count = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {

                var subseq = count.Where(t => t.Key < list[i][0]);
                var val = (subseq.Count() > 0) ?
                    subseq.Max(t => t.Value) + 1 : 1;
                if (count.ContainsKey(list[i][1]))
                {
                    count[list[i][1]] = Math.Max(count[list[i][1]], val);
                }
                else
                    count.Add(list[i][1], val);

            }
            return count.Count() == 0 ? 0 : count.Values.Max();

        }
        public bool IsSubsequence(string s, string t)
        {
            var cur = 0;
            for (int i = 0; i < s.Length; i++)
            {
                while (cur<t.Length && s[i] != t[cur]) {
                    cur++;
                }
                
                if (cur == t.Length) return false;
                if (s[i] == t[cur]) cur++;
            }
            return true;
        }
    }

    public class LongestSubsequenceTest
    {

        [Fact]
        public void EmptyTest() {
            Assert.Equal(0, LongestSubsequence.LengthOfLIS(new int[] { }));
        }

        [Fact]
        public void Only1Test()
        {
            Assert.Equal(1, LongestSubsequence.LengthOfLIS(new int[] { 1}));
        }
        [Fact]
        public void SampleTest()
        {
            Assert.Equal(4, LongestSubsequence.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
        }
        [Fact]
        public void SimilarNumberTest()
        {
            Assert.Equal(1, LongestSubsequence.LengthOfLIS(new int[] { 2,2 }));
        }
        [Fact]
        public void NumbersChainTest()
        {
            Assert.Equal(2, LongestSubsequence.FindLongestChain(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 } }));
        }
        [Fact]
        public void NumbersChainTest2()
        {
            Assert.Equal(2, LongestSubsequence.FindLongestChain(new int[,] { { 3, 4 }, { 2, 3 }, { 1, 2 } }));
        }
        //[[1,2], [2,3], [3,4]]
    }
}
