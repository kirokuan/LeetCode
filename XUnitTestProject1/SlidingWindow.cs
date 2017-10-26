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
 ///       [InlineData("aaaaaaaaaaaabbbbbcdd", "abcdd", "abbbbbcdd")]
        public void test2(string s, string t, string answer)
        {
            Assert.Equal(answer, SlidingWindow.MinWindow(s, t));

        }
    }
}
