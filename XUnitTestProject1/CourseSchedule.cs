using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    class CourseSchedule
    {
        public static bool CanFinish(int numCourses, int[,] prerequisites)
        {
            if (numCourses < 2 || prerequisites.Length == 0) return true;
            var dict = new Dictionary<int, IList<int>>();
            var inDegree = new int[numCourses];
            for (int i = 0; i < prerequisites.Length / 2; i++)
            {
                if (!dict.ContainsKey(prerequisites[i, 0]))
                {
                    dict[prerequisites[i, 0]] = new List<int>();

                }
                dict[prerequisites[i, 0]].Add(prerequisites[i, 1]);
                inDegree[prerequisites[i, 1]]++;

            }
            var bfs = new List<int>(Enumerable.Range(0, numCourses).Where(t => inDegree[t] == 0));
            if (!bfs.Any()) return false;
            var step = 0;

            var MaxStep = (prerequisites.Length / 2) + numCourses;
            var nodeVisited = new List<int>();
            while (step <= MaxStep && bfs.Any())
            {
                var course = bfs[0];
                nodeVisited.Add(course);
                bfs.RemoveAt(0);

                if (dict.ContainsKey(course))
                {
                    bfs.AddRange(dict[course]);
                    bfs = bfs.Distinct().ToList();
                }
                step++;
            }
            return step <= MaxStep && dict.All(t => nodeVisited.Contains(t.Key));
        }

        public static int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            if (prerequisites.Length == 0) return Enumerable.Range(0,numCourses).ToArray();
            var dict = new Dictionary<int, IList<int>>();
            var inDegree = new int[numCourses];
            for (int i = 0; i < prerequisites.Length / 2; i++)
            {
                if (!dict.ContainsKey(prerequisites[i, 1]))
                {
                    dict[prerequisites[i, 1]] = new List<int>();

                }
                dict[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                inDegree[prerequisites[i, 0]]++;
            }


            var bfs = new List<int>();
            bfs.AddRange(Enumerable.Range(0, numCourses).Where(t => inDegree[t] == 0));
            if (!bfs.Any()) return new int[0];
            var courses = new int[numCourses];
            var j = 0;
            while (bfs.Any()) {
                if (j == numCourses) return new int[0];
                courses [j]= bfs[0];
                if (dict.ContainsKey(courses[j]))
                {
                    dict[courses[j]].ToList().ForEach((v) =>
                    {
                        inDegree[v]--;
                    });
                }
       
                bfs = new List<int>(bfs.Skip(1));
                if (dict.ContainsKey(courses[j]))
                {
                    bfs.AddRange(dict[courses[j]].Where(t=>inDegree[t]==0));
                    bfs = bfs.Distinct().ToList();
                }
                j++;
            }
            return j<numCourses?new int[0]:courses;
        }
    }

    public class CourseScheduleTest
    {
        [Fact]
        public void CourseSchedule2()
        {
            Assert.Equal(new int[] {0,2,1 }, CourseSchedule.FindOrder(3, new int[,] { { 1, 0 } }));
        }

        [Fact]
        public void Schedule2test2()
        {
            Assert.Equal(new int[] {  2,1,0 }, CourseSchedule.FindOrder(3, new int[,] { {0,1 }, { 0, 2 },{ 1,2} }));
        }
        [Fact]
        public void Schedule2testCycle()
        {
            Assert.Equal(new int[] {}, CourseSchedule.FindOrder(4, new int[,] { { 1,0 }, { 2,1 }, { 3,2 }, { 1,3 } }));
        }
        [Fact]
        public void test()
        {
            Assert.Equal(false, CourseSchedule.CanFinish(2,new int[,] { { 1, 0 } ,{ 0, 1 } }));
        }
        [Fact]
        public void test2()
        {
            Assert.Equal(true, CourseSchedule.CanFinish(2, new int[,] { { 1, 0 } }));
        }
        [Fact]
        public void test3()
        {
            Assert.Equal(true, CourseSchedule.CanFinish(3, new int[,] { { 0, 1 }, { 0, 2 }, { 1, 2 } }));
        }
        [Fact]
        public void test4()
        {
            Assert.Equal(true, CourseSchedule.CanFinish(3, new int[,] { { 1,0 }, {2,1 } }));
        }
        [Fact]
        public void test5()
        {
            Assert.Equal(true, CourseSchedule.CanFinish(8, new int[,] { {1, 0},{2, 6},{1, 7},{6, 4},{7, 0},{0, 5}}));
         
        }
        [Fact]
        public void test6()
        {
            Assert.Equal(false, CourseSchedule.CanFinish(3, new int[,] { { 0,2 }, { 1, 2 } ,{ 2,0} }));
        }
        [Fact]
        public void test7()
        {
            Assert.Equal(false, CourseSchedule.CanFinish(8, new int[,] { { 1, 0 }, { 2, 6 }, { 1, 7 }, { 5, 1 }, { 6, 4 }, { 7, 0 }, { 0, 5 } }));
        }
    }
}
