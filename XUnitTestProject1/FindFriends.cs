using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode
{
    class FindFriends
    {
        public int FindCircleNum(int[,] M)
        {
            var dict = new Dictionary<int,List<int>>();
            Enumerable.Range(0, M.Length / M.GetLength(0)).ToList()
                .ForEach((i) => {
                    dict[i] = new List<int>();
                });
            for (int i = 0; i < M.Length/M.GetLength(0); i++)
            {
                
                for (int j = i+1; j < M.Length/M.GetLength(1); j++)
                {
                    if (M[i, j] == 1) {
                        dict[i].Add(j);
                        dict[j].Add(i);
                    }
                }
            }
            if (!dict.Any()) return 0;
            var dfs = new Stack<int>();
            dfs.Push(dict.First().Key);
            var visited = new int[M.Length / M.GetLength(0)];
            var count = 1;
            while (dict.Any()) {
                var cur = dfs.Pop();
                if (dict.ContainsKey(cur))
                {
                    dict[cur].ForEach(dfs.Push);
                    dict.Remove(cur);
                }
                if (!dfs.Any()&& dict.Any()) {
                    dfs.Push(dict.Keys.First());
                    count++;
                }

            }
            return count;
        }
    }
    public class FindFriendTest
    {

        [Fact]
        public void test()
        {
            
            Assert.Equal(1, new FindFriends().FindCircleNum(new int[,] { { 1,1,1},{ 1, 1, 1 },{ 1, 1, 1 } }));
        }
        [Fact]
        public void test2()
        {

            Assert.Equal(1, new FindFriends().FindCircleNum(new int[,] { {1, 0, 0, 1}
                                                                        ,{0, 1, 1, 0}
                                                                        ,{0, 1, 1, 1}
                                                                        ,{1, 0, 1, 1} }));
        }
    }
}
