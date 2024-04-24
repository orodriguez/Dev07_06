namespace Tests;

public class ContainsDuplicateTests
{
        [Fact]
           public void Contains_Duplicate_True()
           {
               
               Assert.True(ContainsDuplicate(new[] {1,2,3,1}));
           }
           
           [Fact]
           public void Contains_Duplicate_False()
           {
               Assert.False(ContainsDuplicate(new[] { 1, 2, 3, 4 }));
           }
           
           [Fact]
           public void Contains_Duplicate_MultipleNumbers()
           {
               Assert.True(ContainsDuplicate(new[] { 1,1,1,3,3,4,3,2,4,2 }));
           }
           
           [Fact]
           public void Contains_Duplicate_Empty()
           {
               Assert.False(ContainsDuplicate(new int[] {}));
           }

    public bool ContainsDuplicate(int[] nums)
    { 
        var myDictionary = new Dictionary<int, int>(); 
        foreach (var number in nums) 
        {
            if (myDictionary.ContainsValue(number))
                return true;

            myDictionary[number] = number;
        }
        return false;
    }
}