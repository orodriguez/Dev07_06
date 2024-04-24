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
<<<<<<< HEAD
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new[] { map[complement], i };
            }
            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
        }

        throw new ArgumentException("No solution found");
=======
        var seen = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            var complement = target - current;
            if (seen.TryGetValue(complement, out var seenValue))
                return new[] { seenValue, i };
            seen[current] = i;
        }

        return Array.Empty<int>();
>>>>>>> 8debe9e91e5068eb742a8248bdccc2c93c83b874
    }
}