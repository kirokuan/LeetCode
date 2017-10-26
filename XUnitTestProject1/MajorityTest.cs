using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class MajorityTest
    {
        [Fact]
        public void MajorityTest1()
        {
            Assert.Equal(2, Majority.MajorityNumber(new int[] {1,2,2 }));
        }
        [Fact]
        public void MajorityTest2()
        {
            Assert.Equal(1, Majority.MajorityNumber(new int[] { 1, 1, 2 }));
        }

        [Fact]
        public void Majority2Test()
        {
            Assert.Equal(new int[] { }, Majority.MajorityElement2(new int[] { 1, 2, 3 }));
        }
        [Fact]
        public void Majority2Test2()
        {
            Assert.Equal(new int[] { 1,2}, Majority.MajorityElement2(new int[] { 1, 2}));
        }
    }
}
