using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode
{
    class GrayCodeClass
    {
        public IList<int> GrayCode(int n)
        {
            if (n < 1) return new List<int> { 0};

            if (n == 1) return new List<int>() { 0,1};
            var list = GrayCode(n-1);
            var result = new List<int>(list);

            result.AddRange(list.Reverse().Select(t=>t+(int)Math.Pow(2,n-1)));
            return result;
        }
        public static int getLuckyFloorNumber(int n)
        {
            return Enumerable.Range(1, n * 2)
                .Where(t => !Contain(t,4)&&!Contain(t,13 )).Skip(n - 1).First();
        }
        public static bool Contain(int n,int target) {
            var x = n;
            while (x >=target) {
                if (target > 10)
                {
                    if (x % 100 == target) return true;
                }
                else {
                    if (x % 10 == target) return true;
                }
                x /= 10;
            }
            return false;
        }
        static string[] packNumbers(int[] arr)
        {
            var cur = int.MinValue;
            var count = 0;
            var result = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (cur != arr[i])
                {
                    if (i > 0)
                    {
                        AddResult(cur, count, result);
                    }
                    count = 1;
                    cur = arr[i];
                }
                else {
                    count++;
                }
            }
            AddResult(cur, count, result);
            return result.ToArray();
        }

        private static void AddResult(int cur, int count, List<string> result)
        {
            if (count > 1)
                result.Add(cur + ":" + count);
            else result.Add(cur.ToString());
        }
    }
    public class GrayCodeTest
    {

        [Fact]
        public void test()
        {
            Assert.Equal(new List<int> {0,1,3,2 }, new GrayCodeClass().GrayCode(2));
        }
        [Fact]
        public void test2()
        {
            Assert.Equal(15, GrayCodeClass.getLuckyFloorNumber(12));
        }
    }
}