using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLib
{
    class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var k = 0;
            var result = nums.Select(t => new {
                index = k++,
                num = t
            }).GroupBy(t => t.num).ToDictionary(t => t.Key, p => p.Select(x => x.index).ToList());
            for (var i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (diff == nums[i] && result[diff].Count > 1)
                {
                    return new int[] { i, result[diff][1] };
                }
                else if (result.ContainsKey(diff) && diff != nums[i])
                {
                    return new int[] { i, result[diff][0] };
                }
            }
            return new int[] { };
        }
    }
}
