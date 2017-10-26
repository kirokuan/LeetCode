using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class IntBreak
    {
        public static int IntegerBreak(int n)
        {
            if (n == 1 || n==0) return 1;
            var arr = new int[n];
            arr[0] = 1;
            arr[1] = 1;
            for (int i = 3; i <= n; i++)
            {
                for (int j = i-1; j > 1; j--)
                {
                    arr[i-1] = Math.Max(arr[i-j-1]*j,Math.Max((i-j)*j,arr[i-1]));
                }
            }

            return arr[n-1];
        }
    }
    public class IntBreakTest
    {

        [Theory]
        [InlineData(1,1)]
        [InlineData(2, 1)]//1,1
        [InlineData(3, 2)]//2,1
        [InlineData(4, 4)]//2,2
        [InlineData(5, 6)]//3,2
        [InlineData(6, 9)]//3,3
        [InlineData(7, 12)]//2,2,3, | 3,4
        [InlineData(8, 18)]// 3,3,2

        [InlineData(9, 27)] //3,3,3
        public void test(int n,int answer)
        {
            Assert.Equal(answer, IntBreak.IntegerBreak(n));
        }
    }
}
