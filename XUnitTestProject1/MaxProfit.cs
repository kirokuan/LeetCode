using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class MP
    {
        public static int MaxProfit1(int[] prices)
        {
            var min = Int32.MaxValue;
            var profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                profit = Math.Max(profit, prices[i] - min);
            }
            return profit;
        }
       /* public static int MaxProfit2(int[] prices)
        {
            return 0;
        }*/
    }

    public class MPTest
    {
        [Fact]
        public void test1ele()
        {
            var matrix = new int[] { 7};// -6,4,-3,4,-2
            Assert.Equal(0, MP.MaxProfit1(matrix));
        }
        [Fact]
        public void test2ele()
        {
            var matrix = new int[] { 7, 1 };// -6,4,-3,4,-2
            Assert.Equal(0, MP.MaxProfit1(matrix));
        }

        [Fact]
        public void test3ele()
        {
            var matrix = new int[] { 7, 1,5 };// -6,4,-3,4,-2
            Assert.Equal(4, MP.MaxProfit1(matrix));
        }

        [Fact]
        public void test()
        {
            var matrix = new int[] { 7, 1, 5, 3, 6, 4 };// -6,4,-3,4,-2
            Assert.Equal(5, MP.MaxProfit1(matrix));
        }
        [Fact]
        public void test2()
        {
            var matrix = new int[] { 1, 2, 3, 0, 2 };
          //  Assert.Equal(3, MP.MaxProfit2(matrix));
        }
    }
}
