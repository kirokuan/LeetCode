using System;
using System.Collections.Generic;
using System.Linq;
using TestLib;
using Xunit;
using System.Text;
namespace XUnitTestProject1
{
    public class UnitTest1
    {
    
        public static string Encryption(string password,int[] shifts)
        {
            var newPwd = password.ToCharArray();
            //var shiftTotal = shifts.Where(t => t > i).Count();
            /*
                for (var i=0;i<password.Length;i++)
                {
                    newPwd[i]= newPwd[i]+(shiftTotal%26);
                    if (newPwd[i] > 'z') {
                        newPwd[i] -= 26;
                    }
                }
            */
            return new string(newPwd);
        }
        static string alphabetSeq = "abcdefghijklmnopqrstuvwxyz";
        public static string Encryption2(string password, int[] shifts)
        {
            var newPwd = new StringBuilder();
            var shiftsList = shifts.ToList();
            for (var i = 0; i < password.Length; i++) {
                newPwd.Append(alphabetSeq[(alphabetSeq.IndexOf(password[i]) 
                    + shifts.Where(t => t > i).Count()) % alphabetSeq.Length]);
            }
            return newPwd.ToString();
        }

        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz", "ffffffghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
        public void Encryption2Test(string password,string answer)
        {
            var test = new int[] { 1, 2, 3, 4,5 };
            Assert.Equal(answer, Encryption2(password,test));
        }
        [Theory]
        [InlineData("wxyz", "aaaa")]
        [InlineData("aaaa", "edcb")]
        public void EncryptionTest(string password, string answer)
        {
            //            var magic3 = new MagicOf3();
            var test = new int[] { 1, 2, 3, 4};
            Assert.Equal(answer, Encryption2(password, test));
        }
        

        /*
         *readonly Dictionary<int,string> NumberToRomanMapping{
         {1000,"M"},
         {900,"CM"},
         {500,"D"},
         {400,"CD"},
         {100,"C"},
         {90,"XC"},
         {50,"L"},
         {40,"XL"},
         {10,"X"},
         {9,"IX"},
         {5,"V"},
         {4,"IV"},
         {1,"I"}
    };
    static string[] romanizer(int[] numbers)
    {
        var romanians = new List<string>();
        for (var i = 0; i < numbers.Length; i++)
        {
            var num = numbers[i];
            var romanian = "";
            foreach (var mapping in NumberToRomanMapping.Where(t => num > t.Key))
            {
                var times = Math.Floor(num / mapping.Key);
                romanian += string.Join("", Enumerable.Repeat(mapping.Value, (int)times));
            }
            romanians.Add(romanian);
        }
        return romanians.ToArray();
    }*/


        [Theory]
        [InlineData(3,"111")]
        [InlineData(13, "111111")]
        [InlineData(23, "1111111111111111111111")]
        [InlineData(33, "111111")]
        public void MagicOf3Test(int prime,string answer)
        {
            var magic3 = new MagicOf3();
            Assert.Equal(answer,magic3.GetTimes(prime));
        }
        
       [Fact]
        public void MostFrequentTest()
        {
            "test".ToCharArray();
            var charArr = new char[20];
            
            Assert.Equal("", MagicOf3.GetMostFrequent(new List<int> { }));
        }
        [Fact]
        public void MostFrequentTest2()
        {
            Assert.Equal("2:2", MagicOf3.GetMostFrequent(new List<int> {2,3,4,2 }));
        }
        [Fact]
        public void MaximizeTestEmpty()
        {
            Assert.Equal(new List<int> {  }, MagicOf3.Maximize(new List<int> {  }, 2));
        }
        [Fact]
        public void MaximizeTest()
        {
            Assert.Equal(new List<int> { 4,2, 3, 1 }, MagicOf3.Maximize(new List<int> { 2, 3, 4, 1 },2));
        }

        [Fact]
        public void MaximizeTest2()
        {
            Assert.Equal(new List<int> {2, 4,  3, 1 }, MagicOf3.Maximize(new List<int> { 2, 3, 4, 1 }, 1));
        }
    }
}

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var k = 0;
        var result = nums.Select(t => new {
            index = k++,
            num = t
        }).GroupBy(t => t.num).ToDictionary(t => t.Key, p => p.Select(x => x.index).ToList());
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (diff == nums[i] && result[diff].Count > 1)
            {
                return new int[] { i, result[diff][1] };
            }
            else if (result.ContainsKey(diff) && diff != nums[i])
            {
                return new int[] { i, result[diff][0] };
            }
        }
        return new int[] { };
    }
}