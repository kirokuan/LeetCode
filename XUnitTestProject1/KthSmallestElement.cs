using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class Kth_Smallest_Element
    {
        public static int KthSmallest(int[,] matrix, int k)
        {
            return matrix.Cast<int>()
            .OrderBy(t => t)
            .Skip(k-1).First();

        }

        public static IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var list = nums1.Select(t => nums2.Select(y => new int[] { t, y }))
                .SelectMany(t => t)
                .OrderBy(t => t[0] + t[1]);
                
            return list.Take(k).ToList();
        }

    }
    public class kthTest
    {

        [Fact]
        public void test()
        {

            var answer = 13;
            Assert.Equal(answer, Kth_Smallest_Element.KthSmallest(new int[,] {  {1, 5, 9},
                                                                            { 10, 11, 13},
                                                                            { 12, 13, 15} }, 8));
        }

        [Fact]
        public void test2() {
            var answer = new List<int[]> { new int[]{ 1, 2 }, new int[] { 1, 4 }, new int[] { 1, 6 } };
            Assert.Equal(answer, Kth_Smallest_Element.KSmallestPairs(new int[] {1,7,11 },new int[] {2,4,6 }, 3));

        }
    }
}
