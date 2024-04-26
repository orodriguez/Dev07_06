using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementations;

namespace Tests
{
    public class Assignment4Test
    {
        Assignment4 proof = new Assignment4();
        #region Duplicate Tests
        [Fact]
        public void No_Duplicates()
        {
            int[] nums = { 1, 2, 3, 4, 5, };
            Assert.False(proof.ContainsDuplicate(nums));
        }

        [Fact]
        public void There_are_Duplicates()
        {
            int[] nums = { 1, 1, 2, 3, 4, 5, 5 };
            Assert.True(proof.ContainsDuplicate(nums));
        }
        [Fact]
        public void Lots_No_Duplicates()
        {
            int[] nums = { 1, 5, 9, 10, 15, 50, 2, 78, 3, 8, 99 };
            Assert.False(proof.ContainsDuplicate(nums));
        }
        [Fact]
        public void Lots_With_Duplicates()
        {
            int[] nums = { 1, 5, 9, 10, 1, 50, 2, 35, 2, 40, 99 };
            Assert.True(proof.ContainsDuplicate(nums));
        }
        #endregion
        #region Anagram Tests
        [Fact]
        public void Is_Anagram()
        {
            string s = "anagrama";
            string t = "ngramaaa";
            Assert.True(proof.IsAnagram(s, t));
        }
        [Fact]
        public void Not_Anagram()
        {
            string s = "anna";
            string t = "annn";
            Assert.False(proof.IsAnagram(s, t));
        }
        [Fact]
        public void Anagram_With_Mayus()
        {
            string s = "Anagrama";
            string t = "ngramaaa";
            Assert.True(proof.IsAnagram(s, t));
        }
        [Fact]
        public void Not_Anagram_With_Mayus()
        {
            string s = "NolocOmICOdIgOCoRrIAAyEr";
            string t = "sUreBRolOqUeTuDiGaVaDeAh";
            Assert.False(proof.IsAnagram(s, t));
        }
        [Fact]
        public void Different_Sizes()
        {
            string s = "firststring";
            string t = "firststringg";
            Assert.False(proof.IsAnagram(s, t));
        }
        [Fact]
        public void Anagran_With_Spaces()
        {
            string s = "Ana is Here";
            string t = "  AnaisHere";
            Assert.True(proof.IsAnagram(s, t));
        }
        [Fact]
        public void Special_Character()
        {
            string s = "N@nΘfúa@gmail.com";
            string t = "@Θú@Nnfagmail.com";
            Assert.True(proof.IsAnagram(s, t));
        }
        #endregion
    }
}
