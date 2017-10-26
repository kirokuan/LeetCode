using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode
{
    class HIndexClass
    {
        public int HIndex(int[] citations)
        {
    
            var b = citations.OrderBy(t => t).ToList();
            for (int x = b.Count() - 1; x >= 0; x--)
            {
                if (b.Count()-x > b[x]) return b.Count() - x - 1;
            }
            return b.Count();
        }
        public int HIndex2(int[] citations)
        {
         //   var b = citations.ToList();
            for (int x = citations.Length - 1; x >= 0; x--)
            {
                if (citations.Length - x > citations[x]) return citations.Length - x - 1;
            }
            return citations.Length;
        }
    }
    public class HIndexTest
    {
        [Fact]
        public void test5()
        {
            Assert.Equal(1, new HIndexClass().HIndex(new int[] { 1,1,1}));
        }
        [Fact]
        public void test4()
        {
            Assert.Equal(3, new HIndexClass().HIndex(new int[] { 5, 5, 5 }));
        }
        [Fact]
        public void test3()
        {
            Assert.Equal(5, new HIndexClass().HIndex(new int[] { 5,5,5,5,5 }));
        }
        [Fact]
        public void test6()
        {
            Assert.Equal(1, new HIndexClass().HIndex(new int[] { 0,1 }));
        }
        [Fact]
        public void test7()
        {
            Assert.Equal(1, new HIndexClass().HIndex(new int[] { 1,2 }));
        }
        [Fact]
        public void test()
        {
            Assert.Equal(1, new HIndexClass().HIndex(new int[] { 1}));
        }
        [Fact]
        public void test2()
        {
            Assert.Equal(0, new HIndexClass().HIndex(new int[] { 0 }));
        }
    }
}
