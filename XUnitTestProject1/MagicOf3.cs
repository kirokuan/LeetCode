using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLib
{
    public class MagicOf3
    {
       // public int Seed { get; set; }
        public MagicOf3()
        {
         //   Seed = seed;
        }

        public string GetTimes(int seed) {
            int remainder = 1;
            int times = 1;
            while (remainder % seed != 0)
            {
                remainder = (remainder * 10 + 1) % seed;
                times++;
            }
            return new String('1',times);
        }

        public static string GetMostFrequent(IEnumerable<int> numbers)
        {
            var mostFrequent = numbers.GroupBy(t => t)
                .OrderByDescending(t => t.Count())
               .FirstOrDefault();
            return mostFrequent==null?string.Empty:mostFrequent.Key + ":" + mostFrequent.Count();
        }

        public static IList<int> Maximize(IList<int> numbers, int swapTimes)
        {
            var i = 0;
            var rankingNum=numbers
                .Select(n => new
                {
                    index = i++,
                    num = n
                })
                .OrderByDescending(t => t.num).ToArray();
            //2=>0,3=>1,4=>2,1=>3
            //4=>2,3=>1,2=>0,1=>3
            var times = swapTimes;
            var newNumbers = new List<int>(numbers);
            for (var x=0;x< rankingNum.Count() && times>0;x++)
            {
                var origPos=rankingNum.ElementAt(x).index;
                var move= origPos - x;
                if (move > 0)
                {
                    newNumbers=MoveNumber(newNumbers, origPos, origPos- Math.Min(move, times));
                    times = Math.Max(0, times - move);
                }
            }
            return newNumbers;
        }

        private static List<int> MoveNumber(IList<int> numbers,int originalPos,int finalPos) {
            var num = numbers.ElementAt(originalPos);
            numbers.RemoveAt(originalPos);
            numbers.Insert(finalPos, num);
            return numbers.ToList();
        }
        private static IList<int> MaxValueAhead(IList<int> numbers) {
            if (numbers.Count == 0) return numbers;

            var max = numbers.Max();
            if (numbers.FirstOrDefault() != numbers.Max()) {
               
                var pos=numbers.IndexOf(max);
                numbers.RemoveAt(pos);
                numbers.Insert(pos - 1,max);
            }
            return numbers;
        }
    }
}
