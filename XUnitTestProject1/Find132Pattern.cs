using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode
{
    class Find132PatternClass
    {
        public bool Find132pattern(int[] nums)
        {
            if (nums.Length < 3) return false;
            var stack = new Stack<KeyValuePair<int, int?>>();
            stack.Push(new KeyValuePair<int, int?>(nums[0], null));
            var i = 1;
            //            var min = nums[0];
            while (i < nums.Length)
            {
                if (stack.Peek().Value != null && stack.Peek().Value.Value > nums[i]
                    && stack.Peek().Key < nums[i]
                    )
                {
                    return true;
                }
                else if (nums[i] > stack.Peek().Key)
                {

                    // var list = new List<KeyValuePair<int, int?>>();
                    var min = stack.Peek().Key;
                    while (stack.Any() && (stack.Peek().Value==null || nums[i] > stack.Peek().Value.Value))
                    {
                        var item = stack.Pop();
                    }
                    if (stack.Any() && stack.Peek().Key < nums[i])
                    {
                        return true;
                    }
                    else
                    {
                        stack.Push(new KeyValuePair<int, int?>(min, nums[i]));
                    }
                }
                else if (stack.Peek().Key > nums[i])
                {
                    if (stack.Peek().Value == null)
                    {
                        stack.Pop();
                    }
                    stack.Push(new KeyValuePair<int, int?>(nums[i], null));
                }
                i++;
            }
            return false;
        }
    }

    public class Find132PatternTest
    {

        [Fact]
        public void test()
        {
            Assert.Equal(true, new Find132PatternClass().Find132pattern(new int[] { 3, 5, 0, 3, 4 }));
        }
        [Fact]
        public void test2()
        {
            Assert.Equal(false, new Find132PatternClass().Find132pattern(new int[] { 1, 2, 3, 4 }));
        }
        [Fact]
        public void test3()
        {
            Assert.Equal(false, new Find132PatternClass().Find132pattern(new int[] { 4, 3, 2, 1 }));
        }
        [Fact]
        public void test4()
        {
            Assert.Equal(true, new Find132PatternClass().Find132pattern(new int[] { -2, 1, -1 }));
        }
        [Fact]
        public void test5()
        {
            Assert.Equal(true, new Find132PatternClass().Find132pattern(new int[] { 2, 4, 1, 3 }));
        }
    }
}
