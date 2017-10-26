using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    class OutOfBoundary
    {
        private int[,,] cache;
        public  int FindPaths(int m, int n, int N, int i, int j)
        {
            //if(m==1 && n== 3 && N==3&& i==0&&j==1 ) return 14;
            
            if (N == 0) return 0;
            if (cache != null
               && cache[N - 1, i, j] > 0) return cache[N - 1, i, j];
            var count = 0;
            if (N == 1)
            {

                if (i < 1) count++;
                if (i + 1 >= m) count++;
                if (j < 1) count++;
                if (j + 1 >= n) count++;
                if (cache != null) cache[N - 1, i, j] = count;
                return count;

            }
            if (cache == null) cache = new int[N, m, n];

            if (i + 1 < m) count += FindPaths(m, n, N - 1, i + 1, j);
            else count++;
            if (j + 1 < n) count += FindPaths(m, n, N - 1, i, j + 1);
            else count++;
            count %= (int)(Math.Pow(10, 9) + 7);
            if (i - 1 >= 0) count += FindPaths(m, n, N - 1, i - 1, j);
            else count++;
            count %= (int)(Math.Pow(10, 9) + 7);
            if (j - 1 >= 0) count += FindPaths(m, n, N - 1, i, j - 1);
            else count++;
            cache[N - 1, i, j] = count%(int) (Math.Pow(10,9)+7);
            return cache[N - 1, i, j];
        }
        public long FindPathsWithOutCache(int m, int n, int N, int i, int j)
        {
            var count = 0l;
            if (N == 0) return count;
            if (N == 1)
            {

                if (i < 1) count++;
                if (i + 1 >= m) count++;
                if (j < 1) count++;
                if (j + 1 >= n) count++;
                return count;

            }

            if (i + 1 < m) count += FindPathsWithOutCache(m, n, N - 1, i + 1, j);
            else count++;
            if (j + 1 < n) count += FindPathsWithOutCache(m, n, N - 1, i, j + 1);
            else count++;
            if (i - 1 >= 0) count += FindPathsWithOutCache(m, n, N - 1, i - 1, j);
            else count++;
            if (j - 1 >= 0) count += FindPathsWithOutCache(m, n, N - 1, i, j - 1);
            else count++;
            
            return count;
        }
    }
    public class BoundaryTest
    {

        [Theory]
        [InlineData(1,2,50,0,0,150)]
        [InlineData(1,3,3,0,1,12)]
        [InlineData(8,50,23,5,26, 914783380)]
        [InlineData(8,50,18,5,26, 810636248)]

        public void test(int m, int n, int N, int i, int j,long answer)
        {
            
            Assert.Equal(answer,new OutOfBoundary().FindPaths(m,n,N,i,j));
        }
        
    }
    }
