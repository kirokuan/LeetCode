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
    }
    public class CSTest
    {

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
