using System.Collections.Generic;
using NUnit.Framework;

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        foreach (int num in nums) {
            if (set.Contains(num)) {
                return true;
            }
            set.Add(num);
        }
        return false;
    }
}

[TestFixture]
public class SolutionTests {
    [Test]
    public void Test1() {
        Solution sol = new Solution();
        int[] nums = {1, 2, 3, 1};
        Assert.IsTrue(sol.ContainsDuplicate(nums));
    }
    
    [Test]
    public void Test2() {
        Solution sol = new Solution();
        int[] nums = {1, 2, 3, 4};
        Assert.IsFalse(sol.ContainsDuplicate(nums));
    }
    
    [Test]
    public void Test3() {
        Solution sol = new Solution();
        int[] nums = {1, 1, 1, 3, 3, 4, 3, 2, 4, 2};
        Assert.IsTrue(sol.ContainsDuplicate(nums));
    }
}
