using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class SlidingWindow
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0) return new int[] { };
            var win = new List<int>();
            var max = new int[nums.Length - k + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                if (win.Any() && i + 1 - k > win[0])
                {
                    win = win.Skip(1).ToList();
                }
                win = win.Where(t => nums[t] > nums[i]).ToList();
                win.Add(i);
                if (i > k - 2)
                {
                    max[i - k + 1] = nums[win[0]];
                }
            }
            return max;
        }
        public static string MinWindow(string s, string t)
        {
            var list = new List < Tuple < char ,int>> ();
            var max = "";
            var tSorted = new string(t.OrderBy(z=>z).ToArray());
            for (int i = 0; i < s.Length; i++)
            {
                if (t.IndexOf(s[i]) > -1)
                {
                    list.Add(new Tuple<char, int>(s[i], i));
                    if (list.Count() >= t.Count())
                    {
                        var lastTItems = list.Skip(list.Count() - t.Length);

                        if ( new string(lastTItems
                            .Select(z => z.Item1).OrderBy(z=>z).ToArray()) == tSorted)
                        {
                            var min = lastTItems.Min(z => z.Item2);
                            var leng = lastTItems.Max(z => z.Item2) - min+1;
                            if (max == string.Empty || max.Length > leng)
                            {
                                max = s.Substring(min, leng);
                            }
                        }
                    }
                }
            }
            return max;
        }
        public static string MinWindow2(string s, string t) {
            var k = 0;
            var dict = t.Select(x => new
            {
                index = k++,
                c = x
            }).GroupBy(x => x.c)
            .ToDictionary(x => x.Key, y => y.Select(j => j.index).ToList());
            var filled = t.Distinct().ToDictionary(x=>x,v=>new Queue<int>());//Enumerable.Repeat(-1,t.Length).ToList();
            var max = "";
            var start = -1;
            var end=-1;
            var changed = false;
            var num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i])) {
                    var list = dict[s[i]];
                    filled[s[i]].Enqueue(i);
                    end = i;
                    num++;
                    if (filled[s[i]].Count - 1 == dict[s[i]].Count)
                    {
                        var x = filled[s[i]].Dequeue();
                        num--;
                        if (x == start && num == t.Length)
                        {
                            changed = true;
                            start = filled.Min(p => p.Value.Peek());
                        }
                    }
                    if (num== t.Length)
                    {
                        changed = true;
                        start = filled.Min(p => p.Value.Peek());
                    }
                    if (changed) {
                        if (end - start + 1 < max.Length || string.IsNullOrEmpty(max)) {
                            max = s.Substring(start, end - start + 1);
                        }
                        changed = false;
                    }
                }
            }
            return max;
        }
    }
    public class SWTest
    {

        [Fact]
        public void test()
        {
            Assert.Equal(new int[] { 3, 3, 5, 5, 6, 7 }, SlidingWindow.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3));
        }
        [Theory] //A..B.C....BA.C
        //"aaaaaaaaaaaabbbbbcdd"
//"abcdd"
        [InlineData("ADOBECODEBANC", "ABC", "BANC")]
        [InlineData("aa", "aa", "aa")]
        [InlineData("abc", "cba", "abc")]
       [InlineData("aaaaaaaaaaaabbbbbcdd", "abcdd", "abbbbbcdd")]
       [InlineData("cabeca", "cae", "eca")]
       [InlineData("cabefgecdaecf", "cae", "aec")]
        public void test2(string s, string t, string answer)
        {
            Assert.Equal(answer, SlidingWindow.MinWindow2(s, t));

        }
    }
}
