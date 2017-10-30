using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            var queue = new Queue<int>();
            var sum = 0;
            var min = Int32.MaxValue;
            for (var i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i]);
                sum += nums[i];
                
                if (sum >= s) {
                    while (sum -queue.Peek() >= s) {
                        sum-=queue.Dequeue();
                    }
                    min = Math.Min(min,queue.Count);
                }
            }
            return min;
        }
    }
    public class MSSSTest
    {
        [Fact]
        public void CombinationSum4test()
        {
            Assert.Equal(2, new MinimumSizeSubarraySum().MinSubArrayLen(7,new int[] { 2, 3, 1, 2, 4, 3 }));
        }
    }
   }
