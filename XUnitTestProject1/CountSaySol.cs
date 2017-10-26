
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public class CountSaySol
    {
        public int[] PlusOne(int[] digits)
        {
            digits[digits.Length - 1]= digits[digits.Length - 1] + 1;
            var i = digits.Length - 1;
            while (i>=0 && digits[i] >= 10) {
                digits[i] = 0;
                i--;
                if (i >= 0)
                {
                    digits[i] += 1;
                }
                else {
                    var ii = new int[digits.Length+1];//new List<int>();
                    ii[digits.Length] = 1;
                    return ii;
                }
            }
            return digits;
        }

        public static string CountSay(int n) {
            if (n == 1) return "1";
            string s = "1";
            for (var i = 1; i < n; i++) {
                s = recStr(s);
            }
            return s;
        }

        private static string recStr(string s) {
            char cur ='0';
            int count = 0;
            string result = string.Empty;
            foreach (var c in s) {
                if (cur != c)
                {
                    
                    if (count > 0) {
                        result += count.ToString() + cur;
                    }
                    cur = c;
                    count = 1;
                }
                else {
                    count++;
                }
            }
            result += count.ToString() + cur;
            return result;
        }
    }
}
