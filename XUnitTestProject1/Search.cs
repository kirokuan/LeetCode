using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    class Search
    {
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0) return false;
            int i = 0, j = 0;
            
            var height= matrix.GetLength(0);//Math.Sqrt(matrix.Length);
            var width = matrix.GetLength(1);

            while (i < width && j < height)
            {
                if (matrix[j,i] == target) return true;
                if (matrix[j,i] > target) return false;

                if (j + 1 < height && matrix[ j + 1,i] <= target)
                {
                    j++;
                    continue;
                }
                i++;
            }
            return false;
        }
        public bool SearchMatrix2(int[,] matrix, int target)
        {
            if (matrix.Length == 0) return false;
//            int i = 0, j = 0;

            var height = matrix.GetLength(0);//Math.Sqrt(matrix.Length);
            var width = matrix.GetLength(1);
            return ExistInMatrix(matrix, target, 0, 0, height, width);
        }
        public bool ExistInMatrix(int[,] matrix, int target, int x, int y, int x_end, int y_end)
        {
            if (x >= x_end || y >= y_end) return false;
            if (matrix[x, y] == target) return true;
            if (matrix[x, y] > target) return false;
      //        if(x+1==x_end && y+1==y_end) return false; 

            //         if(x+1==x_end && y+1==y_end) return false;
            var x_mid = (x + x_end) / 2;
            var y_mid = (y + y_end) / 2;
            if (matrix[x_mid, y_mid] > target)
            {
                while (x_mid >=1 && y_mid >=1 && matrix[x_mid , y_mid ] >target)
                {
                    x_mid--;
                    y_mid--;
                }
            }
            else
            {
                while (x_mid + 1 < x_end && y_mid + 1 < y_end 
                    && matrix[x_mid + 1, y_mid + 1] <= target)
                {
                    x_mid++;
                    y_mid++;
                }
            }
            if (matrix[x_mid, y_mid] == target) return true;
            if (matrix[x_mid, y_mid] > target) {
                if (x_mid == x) {
                    return ExistInMatrix(matrix, target, x, y, x_end, y_mid);
                }
                if (y_mid == y)
                {
                    return ExistInMatrix(matrix, target, x, y, x_mid, y_end);
                }
                return false;
            }
            return  ExistInMatrix(matrix, target, x_mid+1, y, x_end, y_mid+1) ||
                    ExistInMatrix(matrix, target, x, y_mid+1, x_mid+1, y_end)
                    ;

            
        }
    }
    public class SearchTest
    {

        [Fact]
        public void test()
        {
            Assert.Equal(true, Search.SearchMatrix(new int[,] { { 1 } }, 1));
        }

        [Fact]
        public void test2()
        {
            Assert.Equal(false, Search.SearchMatrix(new int[,] { { 1 } }, 2));
        }

        [Fact]
        public void test3()
        {
            Assert.Equal(true, Search.SearchMatrix(new int[,] { { 1, 3, 5, 7 }, { 10, 11, 16, 20 }, { 23, 30, 34, 50 } }, 10));
        }

        [Fact]
        public void test1Search2()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                    {1, 4 },{2, 10 } }, 10));
        }
        [Fact]
        public void Search2FalseCase()
        {
            Assert.Equal(false,
                new Search().SearchMatrix2(new int[,] {
                    {1, 2,5 } }, 3));
        }
        [Fact]
        public void Search2BoundaryCase4()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                    {1, 3,5 } }, 5));
        }
        [Fact]
        public void Search2BoundaryCase5()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                    {1,2, 3,4,5 } }, 2));
        }
        [Fact]
        public void Search2Case()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                    {1, 4 }
                    ,{2,5 } }, 2));
        }
        [Fact]
        public void Search2BoundaryCase()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                  {5, 6, 10, 14}
                 ,{6, 10, 13, 18}
                 ,{10, 13, 18, 19}  }, 14));
        }
        [Fact]
        public void Search2BoundaryCase2()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                 {1, 4, 7, 11, 15}
                 ,{2, 5, 8, 12, 19}
                 ,{3, 6, 9, 16, 22}
                 ,{10, 13, 14, 17, 24}
                 ,{18, 21, 23, 26, 30} }, 5));
        }
        [Fact]
        public void Search2BoundaryCase3()
        {
            Assert.Equal(false,
                new Search().SearchMatrix2(new int[,] {
                 {1, 4, 7, 11, 15}
                 ,{2, 5, 8, 12, 19}
                 ,{3, 6, 9, 16, 22}
                 ,{10, 13, 14, 17, 24}
                 ,{18, 21, 23, 26, 30} }, 20));
        }
        [Fact]
        public void Search2BoundaryCase6()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                 {1, 6, 11, 16, 21}
                 ,{2, 7, 12, 17, 22}
                 ,{3, 8, 13, 18, 23}
                 ,{4, 9, 14, 19, 24}
                 ,{5, 10, 15, 20, 25} }, 5));
        }
        [Fact]
        public void Search2BoundaryCase7()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                 {1, 6, 11, 16, 21}
                 ,{2, 7, 12, 17, 22}
                 ,{3, 8, 13, 18, 23}
                 ,{4, 9, 14, 19, 24}
                 ,{5, 10, 15, 20, 25} }, 5));
        }
        [Fact]
        public void Search2BoundaryCase8()
        {
            Assert.Equal(true,
                new Search().SearchMatrix2(new int[,] {
                 { 5, 8, 11, 11, 12, 12, 14, 14, 19}
                ,{ 9, 9, 14, 17, 17, 19, 21, 26, 27}
                ,{12, 15, 15, 21, 21, 26, 30, 35, 36}
                ,{17, 17, 20, 25, 28, 30, 32, 35, 39}
                ,{20, 21, 22, 29, 30, 32, 34, 36, 43}
                ,{24, 24, 25, 31, 36, 40, 40, 43, 45}
                ,{28, 31, 32, 36, 36, 45, 49, 53, 56}
                ,{29, 33, 36, 39, 40, 50, 54, 57, 57}
                ,{34, 36, 37, 41, 42, 53, 55, 58, 59}
                ,{37, 40, 42, 44, 47, 53, 56, 58, 62} },22 ));
        }
  
    }
}
