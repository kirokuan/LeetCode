using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    class Majority
    {
        public static int MajorityNumber(int[] num) {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (!dict.ContainsKey(num[i]))
                {
                    dict.Add(num[i], 1);
                }
                else dict[num[i]]++;
            }
            return dict.First(t => t.Value == dict.Values.Max()).Key;
        }
        public static IList<int> MajorityElement2(int[] num)
        {
            if (num.Length == 0) return new List<int>();
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (!dict.ContainsKey(num[i]))
                {
                    dict.Add(num[i], 1);
                }
                else dict[num[i]]++;
            }
            return dict.Where(t => t.Value == dict.Values.Max() && t.Value> num.Length/3)
                .Select(t => t.Key).ToList();
        }
    }
}
