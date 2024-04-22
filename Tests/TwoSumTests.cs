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
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     if (nums[i] < target)
        //     {
        //         for (int j = i + 1; j  < nums.Length; j++)
        //         {
        //             if(nums[i] + nums[j] == target)
        //             {
        //                 return [i, j];
        //             }
        //         }
        //     }
        // }
        // return[];
        Dictionary<int, int> numberDictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            numberDictionary[nums[i]] = i;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            int needed = target - nums[i];
            if (numberDictionary.ContainsKey(needed) && numberDictionary[needed] != i)
            {
                return [i, numberDictionary[needed]];
            }
        }
        return [];
    }
}