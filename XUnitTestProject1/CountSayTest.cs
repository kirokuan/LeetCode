using Xunit;

namespace XUnitTestProject1
{
    public class CountSayTest
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "11")]
        [InlineData(4, "1211")]
        public void CountSay(int n, string answer)
        {

            Assert.Equal(answer, CountSaySol.CountSay(n));
        }
    }
}