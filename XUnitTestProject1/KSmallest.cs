using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode
{
    class KSmallest
    {
        public int FindKthNumber(int n, int k)
        {
            var x= Enumerable.Range(1, n)
                .Select(t => t.ToString())
                .OrderBy(t => t).ToList();
            return Int32.Parse(x.Skip(k - 1).First().ToString());

        }
    }
    public class KSmallestTest
    {

        [Theory]
        [InlineData(13, 2,10)]
 
        public void test(int n, int k,int answer)
        {
            Assert.Equal(answer,new KSmallest().FindKthNumber(n,k));
        }
    }
}
