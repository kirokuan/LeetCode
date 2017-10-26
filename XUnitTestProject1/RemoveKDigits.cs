using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    class RemoveKDigitsClass
    {
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length == k) return "0";
            var chars = new char[num.Length-k];
            var cur = 0;
            for (int i = 0; i < num.Length - k; i++)
            {
                chars[i] = num[cur];
                cur++;
                var x = cur;
                while (x <  k + i+1) {
                    if (num[x] < chars[i]) {
                        chars[i] = num[x];
                        cur = x+1;
                    }
                    x++;
                }
            }
            var str=new string(chars).TrimStart('0');
            return str.Length == 0 ? "0" : str;
        }
    }
    public class RKDTest
    {

        [Theory]
        [InlineData("1432219", 3, "1219")]
        [InlineData("10200", 1, "200")]
        public void test2(string a, int k, string answer)
        {
            Assert.Equal(answer, new RemoveKDigitsClass().RemoveKdigits(a,k));

        }
    }
}
