using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode
{
    class PartitionEqualSubsetSum
    {
        public bool CanPartition(int[] nums)
        {
            var target = nums.Sum();
            if (target % 2 == 1)
                return false;
            var matrix = new bool[nums.Length+1, target / 2+1];
            for (int i = 0; i < nums.Length+1; i++)
            {
                matrix[i, 0] = true;
            }
            for (int i = 1; i < nums.Length+1; i++)
            {
                for (int j = 0; j <= target/2; j++)
                {
                    matrix[i, j] = matrix[i-1, j ];
                    if (nums[i-1] <= j) {
                        matrix[i, j] |= matrix[i-1, j - nums[i-1]];
                    }
                }
            }
            return matrix[nums.Length,target / 2];
        }
    }

    //[2,3,5] 4
    //  0,1,2,
    //0 F F F
    //0 F T F
    //0 F F T
    //0 F F F
    //0 F F T
    public class PESSTest
    {

        [Fact]
        public void test()
        {
            
            Assert.Equal(true , new PartitionEqualSubsetSum().CanPartition(new int[] {
                19,33,38,60,81,49,13,61,50,73,60,82,73,29,65,62,53,29
                ,53,86,16,83,52,67,41,53,18,48,32,35,51,72,22,22,76,97
                ,68,88,64,19,76,66,45,29,95,24,95,29,95,76,65,35,24,85
                ,95,87,64,97,75,88,88,65,43,79,6,5,70,51,73,87,76,68,56
                ,57,69,77,22,27,29,12,55,58,18,30,66,53,53,81,94,76,28,41,77,17,60,32,62,62,88,61
            }));
        }
        [Fact]
        public void test2()
        {

            Assert.Equal(false, new PartitionEqualSubsetSum().CanPartition(new int[] {1,2,5
            }));
        }
    }
}
