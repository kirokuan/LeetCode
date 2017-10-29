using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class CombinationSumA
    {
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var dict = new Dictionary<int, List<IList<int>>>();
            foreach (var c in candidates) {
                dict[c] = new List<IList<int>>() { new List<int> { c} };
            }
            var comparer = new IntListComparer();
            for (int i = 1; i <= target; i++)
            {
                foreach (var c in candidates.Where(y=>y<i))
                {
                    if (dict.ContainsKey(i - c)) {
                        var newCol = new List<IList<int>>();
                        dict[i - c].ForEach(t => {
                            var list=new List<int>(t) { c };
                            newCol.Add(list.OrderBy(b=>b).ToList()); 
                            
                            });
                        if (dict.ContainsKey(i))
                        {
                            dict[i].AddRange(newCol);
                        }
                        else {
                            dict[i]= newCol;
                        }
                    }
                }
                if (dict.ContainsKey(i))
                {
                    dict[i]=dict[i].Distinct(comparer).ToList();
                }
            }
            return dict.ContainsKey(target)? dict[target]:new List<IList<int>>();
        }

        public int CombinationSum4(int[] nums, int target)
        {
            var gcd = GetGcdFromList(nums);
            if (gcd > 1 ) {
                if (target % gcd == 0)
                {
                    return CombinationSum4(nums.Select(t => t / gcd).ToArray(), target / gcd);
                }
                else return 0;
            }
            var x = new int?[target+1];
            x[0] = 1;
            /*        
            for (int i = 1; i <= target; i++)
            {
                x[i]= nums.Sum(t => i-t>=0?x[i - t]:0);
            }*/
            return TopDown(nums,x,target);
        }
        public int TopDown(int[] nums,int?[] cache, int target) {
            if (cache[target] == null)
            {
                cache[target] = nums.Sum(t => target - t>=0?TopDown(nums, cache, target - t):0);
            }
            return cache[target].Value;
        }
        public int GetGcdFromList(IList<int> list) {
            if (list.Count == 0) return 1; 
            if (list.Count == 1) return list[0];
            var baseNum = GetGcd(list[0], list[1]);
            for (int i = 2; i < list.Count; i++)
            {
                baseNum= GetGcd(list[i],baseNum);
                if (baseNum == 1) return 1;
            }
            return baseNum;
        }
        public int GetGcd(int a, int b) {
            if (a == b) return a;
            if (b > a) return GetGcd(b, a);
            var c = a;
            var d = b;
            while (c%d!=0)
            {
                var tmp = c % d;
                c = d;
                d = tmp;
            }
            return d;
        }
    }
    public class CSTest
    {
        [Fact]
        public void CombinationSum4test()
        {
            Assert.Equal(7, new CombinationSumA().CombinationSum4(new int[] { 1,2,3 }, 4));
        }
        [Fact]
        public void CombinationSum4test2()
        {
            Assert.Equal(0, new CombinationSumA().CombinationSum4(new int[] { 3,33,333 }, 100000));
        }
        [Fact]
        public void test()
        {
            var answer = new List<IList<int>>() { new List<int> { 7 },new List<int> {2,2,3 } };
            Assert.Equal(answer, CombinationSumA.CombinationSum(new int[] { 2,3,6,7},7));
        }

        [Fact]
        public void test2()
        {
            var answer = new List<IList<int>>() { };
            Assert.Equal(answer, CombinationSumA.CombinationSum(new int[] { 2}, 1));
        }
    }
}
