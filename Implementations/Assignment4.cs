using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class Assignment4
    {
        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int target = nums[i];
                if (dictionary.TryGetValue(target, out var seen))
                {
                    return true;
                }
                dictionary[nums[i]] = i;
            }
            return false;
        }
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            /*According to the original Excercise's constraint,
            s and t will always be lowercase (https://leetcode.com/problems/valid-anagram/description/).
            To make sense of this, I won't be evaluating cases, bringing everything to lower case
             */
            foreach (char c in s.ToLower())
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            foreach (char c in t.ToLower())
            {
                if (!charCount.ContainsKey(c) || charCount[c] == 0)
                {
                    return false;
                }
                charCount[c]--;
            }
            return true;
        }
    }
}
