
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    class LVP
    {
        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var stack = new Stack<int>();
            var count = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                if (s[i] == ')' && stack.Count > 0 && s[stack.Peek()] == '(')
                {
                    var z = stack.Pop();
                    if (count.ContainsKey(z - 1))
                    {
                        count[i] = count[z - 1] + i - z + 1;
                    }
                    else
                    {
                        count.Add(i, i - z + 1);
                    }

                }
            }
            return count.Count() > 0 ? count.Values.Max() : 0;
        }
    }

    public class LVPTest
    {

        [Theory]
        [InlineData("", 0)]
        [InlineData("(()", 2)]//-1,-1,2
        [InlineData(")()())", 4)]//0,-1,2,-1,2,0
        [InlineData("()(()", 2)]//-1,2,-1,-1,2
        [InlineData("()(())", 6)]//-1,2,-1,-1,2,2

        public void test(string s, int answer)
        {
            Assert.Equal(answer, new LVP().LongestValidParentheses(s));
        }
    }
}
