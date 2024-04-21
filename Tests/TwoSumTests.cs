namespace Tests;

// Read: https://leetcode.com/problems/two-sum/description/
public class TwoSumTests
{
    [Fact]
    public void Test_Simple()
    {
        Assert.Equal(new[] { 0, 2 },
            TwoSum(new[] { 2, 6, 7, 11, 15 }, 9));
    }
    [Fact]
    public void Test_Simple2()
    {
        Assert.Equal(new[] { 1, 2 },
            TwoSum(new[] { 3, 2, 4 }, 6));
    }
    [Fact]
    public void Test_Simple3()
    {
        Assert.Equal(new[] { 0, 1 },
            TwoSum(new[] { 3, 3 }, 6));
    }
    [Fact]
    public void NoSolutionExists()
    {
        Assert.Equal(new int[0],
            TwoSum(new[] { 1, 2, 3, 4, 5 }, 10));
    }
    [Fact]
    public void EmptyArray_ShouldReturnEmpty()
    {
        Assert.Equal(new int[0],
            TwoSum(new int[0], 10));
    }
    private int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> nIndices = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            int t= target - nums[i];
            if (nIndices.ContainsKey(t))
            {
                return new int[] { nIndices[t], i };
            }
            nIndices[nums[i]] = i;
        }
        return new int[0];
    }
}