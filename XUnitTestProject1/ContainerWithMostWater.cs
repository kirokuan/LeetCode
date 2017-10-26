using System;

namespace XUnitTestProject1
{
    class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int left = 0, right = height.Length-1;
            int max = (right-left)*Math.Min(height[left],height[right]);
            while (left != right) {
                max = Math.Max(max,(right - left) * Math.Min(height[left], height[right]));
                if (height[left] < height[right])
                {
                    left++;
                }
                else {
                    right--;
                }

            }

            return max;

        }
    }
}
