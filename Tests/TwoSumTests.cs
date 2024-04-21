namespace Tests;

// Read: https://leetcode.com/problems/two-sum/description/
public class TwoSumTests
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(new[] { 0, 2 },
            TwoSum(new[] { 2, 6, 7, 11, 15 }, 9));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(new[] { 1, 2 },
            TwoSum(new[] { 3, 2, 4 }, 6));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(new[] { 0, 1 },
            TwoSum(new[] { 3, 3 }, 6));
    }

    private int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> myDictionary = new ();
        for (var i = 0; i < nums.Length; i++) {
            if (myDictionary.ContainsKey(target - nums[i]))
                return new int[] {myDictionary[target - nums[i]], i};
            
            myDictionary[nums[i]] = i;
        }

        return [];
    }
}