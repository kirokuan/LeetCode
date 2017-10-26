using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class PerfectSquare
    {
        public int NumSquares(int n)
        {
            var result = new int[n];
            var cur = 1;
            for (int i = 0; i < n; i++)
            {
                if (cur * cur == i + 1)
                {
                    result[i] = 1;
                    cur++;
                }
                else {
                    var x = cur-1;
                    result[i] = result[i - 1] + 1;
                    while (x > 0) {
                        result[i] = Math.Min(result[i],result[i-x*x]+1);
                        x--;
                    }
                }
            }
            return result[n-1];
        }
    }
}
