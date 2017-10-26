using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class IntListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> x, IList<int> y)
        {
            if (x.Count() != y.Count()) return false;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        public int GetHashCode(IList<int> obj)
        {
            if (obj.Count < 2) return 0;
            return obj.Aggregate((x, y) => {
                return x * 10 + y;
            });
        }
    }
    class Combination
    {
        
        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var comparer = new IntListComparer();
            return Subsets(nums).Select(t=>t.OrderBy(x=>x).ToArray()).Distinct(comparer).ToList();
        }
        public static IList<IList<int>> Subsets(int[] nums)
        {
            var list = new List<IList<int>>();
            var index = 0;
            var numList = nums.Select(t => new {
                i =(int) Math.Pow(2,index++),
                num=t
            }).ToList();
            for (int i = 0; i < Math.Pow(2,nums.Length); i++)
            {
                list.Add(numList.Where(x=>(x.i & i) == x.i).Select(t=>t.num).ToList());
            }
            return list;
        }
        private static IList<IList<int>> permute(int[] nums, int start)
        {
            if (start+1 == nums.Count()) return new List<IList<int>>() { new List<int>(nums) };
            else {
                var x = new List<IList<int>>();
                for (int i = start; i < nums.Length; i++)
                {
                    var newNums = new List<int>(nums);
                    //                    var tmp = newNums[start];
                    newNums[i] = nums[start];
                    newNums[start] = nums[i];
                    x.AddRange(permute(newNums.ToArray(), start + 1));
                   
                }

                
                return x;
            }
        }
        public static IList<IList<int>> Permute(int[] nums)
        {
            return permute(nums, 0);
        }
    }

    public class combinationTest {
        [Fact]
        public void test2()
        {
              Assert.Equal(8, Combination.Subsets(new int[] { 1,2,3}).Count);
        }
        [Fact]
        public void testPermuteBasic()
        {
            Assert.Equal(1, Combination.Permute(new int[] { 1 }).Count);
        }

        [Fact]
        public void testPermuteBasic2()
        {
            Assert.Equal(2, Combination.Permute(new int[] { 1,2 }).Count);
        }


        [Fact]
        public void testPermute()
        {
            var c = Combination.Permute(new int[] { 1, 2, 3 });
            Assert.Equal(6, c.Count);
        }
    }
}
