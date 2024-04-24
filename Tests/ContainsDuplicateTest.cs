namespace Test {
    public class ContainsDuplicateTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(ContainsDuplicate(new[] { 1, 2, 3, 1 }));
        }

        [Fact]
        public void Test2()
        {
            Assert.False(ContainsDuplicate(new[] { 1, 2, 3, 4 }));
        }

        [Fact]
        public void Test3()
        {
            Assert.True(ContainsDuplicate(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }));
        }

        private bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>();

            foreach (var num in nums)
            {
                if (set.Contains(num))
                    return true;

                set.Add(num);
            }

            return false;
        }
    }
}