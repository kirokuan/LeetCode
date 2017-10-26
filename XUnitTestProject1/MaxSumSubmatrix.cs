using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class MSS
    {
        public static int MaxSumSubmatrix(int[,] matrix, int k)
        {
            return 0;
        }
    }
    public class MSSTest {

        [Fact]
        public void test() {
            var matrix = new int[,] { {1, 0, 1 },
  { 0, -2, 3} };
            Assert.Equal(0, MSS.MaxSumSubmatrix(matrix,2));
        }
    }
}
