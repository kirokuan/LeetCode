using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class FMHTrees
    {
        public static IList<int> FindMinHeightTrees(int n, int[,] edges)
        {
            if (n == 1) return new List<int>() { 0};
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.Length/edges.Rank; i++)
            {
                CreateAdj(edges[i, 0], dict, edges[i, 1]);
                CreateAdj(edges[i, 1], dict, edges[i, 0]);

            }
            var bfsList = new List<int>(dict.Where(t=>t.Value.Count==1).Select(t=>t.Key));
            while (bfsList.Any()) {
                var next = new List<int>();
                foreach (var i in bfsList)
                {
                    foreach (var y in dict[i]) {
                        dict[y].Remove(i);
                        if (dict[y].Count() == 1) next.Add(y);
                    }

                }
                if (!next.Any()) return bfsList;
                bfsList = next;
            }
            return bfsList;
        }

        private static void CreateAdj(int head, Dictionary<int, List<int>> dict, int tail)
        {
            if (!dict.ContainsKey(head))
            {
                dict[head] = new List<int>() { tail};
            }
            else
            {
                dict[head].Add(tail);
            }
        }
    }
    public class FindMinHeightTreesTest
    {

        [Fact]
        public void test()
        {

            var answer = new List<int>() {1 };
            var n = 4;
            Assert.Equal(answer, FMHTrees.FindMinHeightTrees(n,new int[,] {  {1, 0}, {1, 2}, {1, 3}}));
        }
    }
 }
