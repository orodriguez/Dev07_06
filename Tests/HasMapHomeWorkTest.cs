namespace Tests

{
    public class SolutionTests
    {
        [Fact]
        public void IsAnagram_ValidAnagrams_ReturnsTrue()
        {
          
            var solution = new Solution();
            string word1 = "listen";
            string word2 = "silent";

            
            bool result = solution.IsAnagram(word1, word2);

            
            Assert.True(result);
        }

        [Fact]
        public void IsAnagram_NotAnagrams_ReturnsFalse()
        {
            
            var solution = new Solution();
            string word1 = "hello";
            string word2 = "world";

            
            bool result = solution.IsAnagram(word1, word2);

           
            Assert.False(result);
        }

        [Fact]
        public void ContainsDuplicate_ArrayWithDuplicates_ReturnsTrue()
        {
          
            var solution = new Solution();
            int[] nums = { 1, 2, 3, 1 };

           
            bool result = Solution.ContainsDuplicate(nums);

            
            Assert.True(result);
        }

        [Fact]
        public void ContainsDuplicate_ArrayWithoutDuplicates_ReturnsFalse()
        {
            
            var solution = new Solution();
            int[] nums = { 1, 2, 3, 4 };

           
            bool result = Solution.ContainsDuplicate(nums);

            
            Assert.False(result);
        }
    }
}
