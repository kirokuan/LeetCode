using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class BigNum
    {
        public static string Multiply(string num1, string num2)
        {
            var leng = num1.Length + num2.Length;
            var list = new int[leng];
            for (int i = 0; i < num1.Length; i++)
            {
                var red = 0;
                for (int j = 0; j < num2.Length; j++)
                {
                    var prod = Int32.Parse(num1[num1.Length - 1 - i].ToString())
                       * Int32.Parse(num2[num2.Length - 1 - j].ToString());
                    list[i + j] += prod;
                }
            }
            var sb = new StringBuilder();
            for (int i = 0; i < leng; i++)
            {
                sb.Append((list[i] % 10).ToString());
                if (list[i] >= 10) {
                    list[i + 1] += list[i] / 10;
                }
            }
            var final=new string(sb.ToString().TrimEnd('0').ToCharArray().Reverse().ToArray());
            return final.Length < 1 ? "0" : final;
        }
    }

    public class BigNumTest
    {

        [Theory]
        [InlineData("0","0","0")]
        [InlineData("1","1","1")]
        [InlineData("9","9","81")]
        [InlineData("5","12","60")]
        public void test(string a,string b, string answer)
        {
            Assert.Equal(answer, BigNum.Multiply(a,b));
        }
    }
}
