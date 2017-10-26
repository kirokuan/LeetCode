using System;
using Xunit;

namespace LeetCode
{
    class DeleteOperationforTwoStrings
    {
        public int MinDistance(string word1, string word2)
        {
            int[,] matrix = new int[word1.Length+1, word2.Length+1];
            for (int i = 0; i <= word1.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (int j = 0; j <= word2.Length; j++)
            {
                matrix[0, j] = j;
            }
            for (int i = 1; i < word1.Length+1; i++)
            {
                for (int j = 1; j < word2.Length+1; j++)
                {   //B,C
                    //AB, AE
                    //ABC,BCD
                    // matrix [i,j] is string word1.substring of length i, 
                    // string n length j edit distance
                    matrix[i, j] = word1[i-1]==word2[j-1]?matrix[i-1,j-1]:
                        Math.Min(matrix[i , j - 1]+1, matrix[i - 1, j ]+1)
                        ;
                }
            }
            return matrix[word1.Length,word2.Length];
        }
    }
    public class DOTSTest
    {
        
        [Theory] 
        [InlineData("ABC", "BCD", 2)]
        [InlineData("", "a", 1)]
        public void test2(string a,string b, int answer)
        {
            Assert.Equal(answer,new DeleteOperationforTwoStrings().MinDistance(a,b));

        }
    }
}