using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class FKL
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            var que = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (que.Count < k)
                {
                    que.Add(nums[i]);
                    if (que.Count == k)
                    {
                        que = que.OrderBy(t => t).ToList();
                    }
                }
                else {
                    if (nums[i] > que.First()) {
                        que.RemoveAt(0);
                        que.Add(nums[i]);
                        que = que.OrderBy(t => t).ToList();
                    }
                }
            }
            return que.First();
        }
    }
    public class FindKthLargestTest
    {

        [Fact]
        public void test()
        {
            Assert.Equal(5, FKL.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2));
        }
    }
 }
