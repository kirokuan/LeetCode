using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{

    //  Definition for an interval.
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
        public override string ToString()
        {
            return start + ":" + end;
        }
    }

    class MergeInterval
    {
        public static IList<Interval> Merge(IList<Interval> intervals)
        {
            var newList = intervals.OrderBy(t => t.start).ToList();
            var result = new List<Interval>();
            int i = 0;
            while (i < newList.Count())
            {
                var interv = new Interval()
                {
                    start = newList[i].start,
                    end = newList[i].end,
                };
                var j = i + 1;
                while (j < newList.Count() && newList[j].start <= interv.end)
                {
                    interv.end = Math.Max(newList[j].end, interv.end);
                    i = j;
                    j++;
                }

                result.Add(interv);
                i++;
            }
            return result;
        }
    }
    public class MergeIntervalTest
    {

        [Fact]
        public void test()
        {
            var result = MergeInterval
                .Merge(new List<Interval> { new Interval(1, 3), new Interval(2, 6), new Interval(8, 10), new Interval(12, 15) })
                .Select(t => t.ToString()).ToList();
                
            Assert.Equal(new List<Interval> { new Interval(1, 6), new Interval(8, 10), new Interval(12, 15) }
                          .Select(t => t.ToString()).ToList()
            ,result );
        }
    }
}
