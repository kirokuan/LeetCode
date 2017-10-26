using System.Collections;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    class HammingDistance
    {
        public static int Get(int x, int y)
        {
            var b = new BitArray(new int[] { x^y });
            return b.Cast<bool>().Where(t => t).Count();
        }

        public static int Total(int[] nums)
        {
            if (nums.Count() == 0) return 0;
            var bitArray=nums.Select(t => new BitArray(new int[] { t })).ToList();
            var sum = 0;
            for (int i = 0; i < bitArray[0].Length; i++)
            {
                var t=bitArray.Where(y=>y[i]).Count();
                sum += t*(bitArray.Count() - t);
            }    
            return sum;
        }
    }

    public class HammingDistanceTest
    {
        [Theory]
        [InlineData(1,4,2)]
        public void HammingDist(int a,int b,int answer)
        {
            Assert.Equal(answer, HammingDistance.Get(a,b));
        }

        [Fact]
        public void HammingDistTotal()
        {
            var answer = 6;
            Assert.Equal(answer, HammingDistance.Total(new int[] {4,14,2 }));
        }
    }
}
