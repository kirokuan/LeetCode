using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    class SurroundedRegions
    {


        public int NumIslands(char[,] grid)
        {
            var count = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '1')
                    {
                        count++;
                        Sink(i, j, grid);
                    }
                }
            }
            return count;
        }

        private void Sink(int i, int j, char[,] grid)
        {
            grid[i, j] = '0';
            if (i + 1 < grid.GetLength(0) && grid[i + 1, j] == '1')
            {
                Sink(i + 1, j, grid);
            }
            if (j + 1 < grid.GetLength(1) && grid[i, j + 1] == '1')
            {
                Sink(i, j + 1, grid);
            }
            if (i >= 1 && grid[i - 1, j] == '1')
            {
                Sink(i - 1, j, grid);
            }
            if (j >= 1 && grid[i, j - 1] == '1')
            {
                Sink(i, j - 1, grid);
            }
        }

    }
}
