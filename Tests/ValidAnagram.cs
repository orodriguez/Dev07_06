using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class SolutionTests {
    [Test]
    public void Test1() {
        Solution solution = new Solution();
        string s = "anagram";
        string t = "nagaram";
        Assert.IsTrue(solution.IsAnagram(s, t));
    }
    
    [Test]
    public void Test2() {
        Solution solution = new Solution();
        string s = "rat";
        string t = "car";
        Assert.IsFalse(solution.IsAnagram(s, t));
    }
    
    [Test]
    public void Test3() {
        Solution solution = new Solution();
        string s = "listen";
        string t = "silent";
        Assert.IsTrue(solution.IsAnagram(s, t));
    }
}

public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;
        
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        
        foreach (char c in s) {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }
        
        foreach (char c in t) {
            if (!charCount.ContainsKey(c) || charCount[c] == 0)
                return false;
            charCount[c]--;
        }
        
        return true;
    }
}