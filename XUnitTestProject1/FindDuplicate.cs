using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    class FindDuplicateClass
    {
        public int FindDuplicate(int[] nums)
        {

            return nums.GroupBy(t => t).Where(t => t.Count() > 1).Select(t => t.Key).First();
           
        }
    }
}
