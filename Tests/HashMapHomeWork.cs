namespace Tests;


    public class Solution
    {
        public bool IsAnagram(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in word1)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            foreach (char c in word2)
            {
                if (!charCount.ContainsKey(c) || charCount[c] == 0)
                    return false;

                charCount[c]--;
            }

            return true;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                if (!set.Add(num))
                {
                    return true;
                }
            }
            return false;
        }
}

  