using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    class DecodeWays
    {

        public static int Determine(string s) {
            if (string.IsNullOrEmpty(s)|| s.StartsWith("0")) return 0;
            if (s.Length == 1) return 1;
            var count = new List<int>() {1,1};
            var encodingBound = 26;
            for (int i = 1; i < s.Length; i++)
            {
                count.Add(count[i - 1]);
                var num = System.Int32.Parse(s.Substring(i-1 , 2));
                if ( num <= encodingBound && s[i] != '0' && num > 10)
                {
                    count[i + 1] = count[i] + count[i - 1];
                }
                else if (num > encodingBound && s[i] != '0')
                {
                    count[i + 1] = count[i];
                }
                else if(num > encodingBound || num ==0)
                {
                    return 0;
                }
                
            }
            return count.Last();
        }
    }
    public class DecodeWaysTest{

        [Theory]
        [InlineData("0", 0)]

        [InlineData("1",1)]
        [InlineData("10", 1)]
        [InlineData("11", 2)]
        [InlineData("101", 1)]
        [InlineData("110", 1)]
        [InlineData("111", 3)]
        [InlineData("227", 2)]
        [InlineData("230", 0)]


        [InlineData("12",2)]
        [InlineData("8", 1)]
        [InlineData("27", 1)]
        [InlineData("26", 2)]

        public void DecodeWayTest(string encrpted, int answer) {
            Console.WriteLine(encrpted);
            Assert.Equal(answer, DecodeWays.Determine(encrpted));
        }

    }
}
