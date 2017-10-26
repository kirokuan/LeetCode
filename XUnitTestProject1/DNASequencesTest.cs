using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class DNASequencesTest
    {
        [Fact]
        public void DnaSequenceTestsBasic()
        {
            var answer = new List<string>() { "AAAAACCCCC", "CCCCCAAAAA" };
            Assert.Equal(answer, DNASequences.FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"));
        }
        
        [Fact]
        public void DnaSequenceTestsBasic2()
        {
            var answer = new List<string>() { "AAAAAAAAAA" };
            Assert.Equal(answer, DNASequences.FindRepeatedDnaSequences("AAAAAAAAAAAA"));
        }
        [Fact]
        public void DnaSequenceTestsBasic3()
        {
            var answer = new List<string>() { "AAAAAAAAAA" };
            Assert.Equal(answer, DNASequences.FindRepeatedDnaSequences("AAAAAAAAAAA"));
        }
    }
}
