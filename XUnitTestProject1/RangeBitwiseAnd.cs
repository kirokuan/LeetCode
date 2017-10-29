using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    class RangeBitwiseAndClass
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == n) return m;
            var pow = Math.Floor(Math.Log(m,2))+1;            
            if (Math.Pow(2, pow) <= n) return 0;
            var high = (int)Math.Pow(2, pow - 1);
            return high + RangeBitwiseAnd(m ^ high, n ^ high);
        }
    }
    public class RangeBitwiseAndTest
    {
        [Theory] 
        [InlineData(2, 3, 2)]
        [InlineData(5, 7, 4)]
        [InlineData(5, 8, 0)]
        [InlineData(15, 16, 0)]
        public void test(int m, int n, int answer)
        {
            Assert.Equal(answer, new RangeBitwiseAndClass().RangeBitwiseAnd(m,n));

        }

    }

}
