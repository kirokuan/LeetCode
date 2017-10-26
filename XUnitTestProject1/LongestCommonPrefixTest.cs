
using Xunit;

namespace XUnitTestProject1
{
    public class LongestCommonPrefixTest
    {
        [Theory]
        [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        public void test(string a,string b)
        {
           Assert.Equal(b,LongestCommonPrefixClass.ReverseWords(a));
        }
    }
}
