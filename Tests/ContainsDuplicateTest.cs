using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ContainsDuplicateTest
    {
        [Fact]
        public void ContainDuplicate()
        {
            Assert.True(ContainsDuplicate([1, 2, 1, 3]));
        }
        [Fact] public void ContainDuplicate2()
        {
            Assert.True(ContainsDuplicate([1, 1, 2, 6, 8, 4, 4]));
        }
        [Fact]
        public void Doesnt_ContainDuplicate()
        {
            Assert.False(ContainsDuplicate([1, 2, 3, 4]));
        }
        public bool ContainsDuplicate(int[] nums)
        {
            if(nums.GetType() != typeof(int[]))
            {
                throw new InvalidDataException();
            }
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashMap.ContainsKey(nums[i]))
                {
                    return true;
                }
                hashMap[nums[i]] = i;
            }
            return false;
        }
    }
}
