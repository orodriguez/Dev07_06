namespace Tests;

// Read: https://leetcode.com/problems/two-sum/description/
public class TwoSumTests
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(new[] { 0, 1 },
            TwoSum(new[] { 2, 7, 11, 15 }, 9));
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
        var Miro = new Dictionary<int, int>();
        for (var C = 0; C < nums.Length; C++)
        {
            var current = nums[C];
            var complement = target - current;
            if (Miro.TryGetValue(complement, out var seenValue))
                return new[] { seenValue, C };
            Miro[current] = C;
        }

        return Array.Empty<int>();
    }
}