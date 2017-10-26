using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class Robbery
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            var list = new int[nums.Length];
            list[0] = nums[0];
            list[1] = nums[1];
         
            for (int i = 2; i < nums.Length; i++)
            {
                list[i] = Math.Max(list[i - 2] + nums[i]
                    ,list[i-1]-nums[i-1]+nums[i]
                    );
            }
            return Math.Max(list[nums.Length-1], list[nums.Length - 2]);
        }
        public int Rob2(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            return Math.Max(Rob(nums.Take(nums.Length - 1).ToArray()), Rob(nums.Skip(1).ToArray()));
        }
    }
    public class RobberyTest
    {
        [Fact]
        public void RobberyTest1()
        {
            Assert.Equal(2,new Robbery().Rob(new int[] { 1,1,1}) );
        }
        [Fact]
        public void Robbery2Test()
        {
            Assert.Equal(1, new Robbery().Rob2(new int[] { 1,1,1}));
        }
        [Fact]
        public void Robbery2Test2()
        {
            Assert.Equal(3, new Robbery().Rob2(new int[] { 1,2,1,1 }));
        }
        [Fact]
        public void Robbery2Test3()
        {
            Assert.Equal(3, new Robbery().Rob2(new int[] { 2,1,1,2 }));
        }
    }
}
