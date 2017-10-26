using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    class Palindrome
    {
        public static int CountSubstrings(string s)
        {
            bool[,] matrix = new bool[s.Length, s.Length];
            //init
            for (int i = 0; i < s.Length; i++)
            {
                matrix[0,i] = true;
                if (i < s.Length - 1)
                {
                    matrix[1,i] = s[i] == s[i + 1];
                }
            }
            for (int i = 2; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length-i; j++)
                {
                    matrix[i, j] = matrix[i - 2,j+1] && s[j]==s[j+i];
                    if (matrix[i, j]) {
                        Console.WriteLine(s.Substring(j,i));
                    }
                }
            }
            return matrix.Cast<bool>().Count(t => t);
        }
        //search pattern
        public static int CountSubstrings2(string s)
        {
            var palString = new List<int>();
            for (int i = 0; i < s.Length-1; i++)
            {
                //even pattern
                if (s[i + 1] == s[i]) {
                    var length = 0;
                    while (i - length >= 1 && i + 2 + length<s.Length && s[i-length-1]== s[i+2+length]) {

                        length++;
                    }
                    palString.Add(2+2*length);
                }
                //odd pattern
                if (i>=1 && s[i - 1] == s[i+1])
                {
                    var length = 1;
                    while (i - length>=1 && i + 1 + length <s.Length&& s[i-1-length]==s[i+1+length])
                    {
                        length++;
                    }
                    palString.Add(1 + 2 * length);
                }
            }

            return s.Length+ palString.Select(t=>(int)(t/2)).Sum();

        }
        public static  string LongestPalindrome(string s)
        {
            if (s.Length == 0) return string.Empty;
            var longestSubstr = s[0].ToString();
            for (int i = 0; i < s.Length - 1; i++)
            {
                //even pattern
                if (s[i + 1] == s[i])
                {
                    var length = 0;
                    while (i - length >= 1 && i + 2 + length < s.Length && s[i - length - 1] == s[i + 2 + length])
                    {
                        length++;
                    }
                    if (longestSubstr.Length < 2 + 2 * length) {
                        longestSubstr = s.Substring(i-length, 2 + 2 * length);
                    }
                }
                //odd pattern
                if (i >= 1 && s[i - 1] == s[i + 1])
                {
                    var length = 1;
                    while (i - length >= 1 && i + 1 + length < s.Length && s[i - 1 - length] == s[i + 1 + length])
                    {
                        length++;
                    }
                    if (longestSubstr.Length < 1 + 2 * length)
                    {
                        longestSubstr = s.Substring(i -length, 1 + 2 * length);
                    }
                }
            }
            return longestSubstr;
        }
        public static bool IsPalindrome(int x)
        {
            var reminder = x;
            var cur = 0;
            while (reminder >0) {
                cur = cur * 10 + (reminder % 10);
                reminder /= 10;
            }
            return cur==x;
        }
    }

    public class PalindromeTest
    {

        [Theory]
        [InlineData("aa", 3)]
        [InlineData("aaa",6)]
        [InlineData("aba", 4)]
        [InlineData("aab", 4)]
        [InlineData("abc",3)]
        [InlineData("aaaaa",15)]

        [InlineData("gwwxvxvg", 11)]
        [InlineData("dnncbwoneinoplypwgbwktmvkoimcooyiwirgbxlcttgteqthcvyoueyftiwgwwxvxvg", 77)]
        public void test(string s, int answer)
        {
            Assert.Equal(answer, Palindrome.CountSubstrings(s));
        }
        [Theory]
        [InlineData("11",true)]
        [InlineData("121", true)]
        public void NumberTest(int s, bool answer)
        {
            Assert.Equal(answer, Palindrome.IsPalindrome(s));
        }
        [Theory]
        [InlineData("aa", 3)]
        [InlineData("aaa", 6)]
        [InlineData("aba", 4)]
        [InlineData("aab", 4)]
        [InlineData("abc", 3)]
        [InlineData("aaaaa", 15)]

        [InlineData("gwwxvxvg", 11)]
        [InlineData("dnncbwoneinoplypwgbwktmvkoimcooyiwirgbxlcttgteqthcvyoueyftiwgwwxvxvg", 77)]
        public void TestWithNewMethod(string s, int answer)
        {
            Assert.Equal(answer, Palindrome.CountSubstrings2(s));
        }
        //"babad""cbbd"
        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        public void LongestTest(string s, string answer)
        {
            Assert.Equal(answer, Palindrome.LongestPalindrome(s));
        }
    }
}
