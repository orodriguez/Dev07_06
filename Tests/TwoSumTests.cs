namespace Tests;

// Read: https://leetcode.com/problems/two-sum/description/
public class TwoSumTests
{
    [Fact]
    public void Prueba1()
    {
        Assert.Equal(new[] { 0, 1 },
            Sumando(new[] { 2, 7, 11, 15 }, 9));
    }

    [Fact]
    public void Prueba2()
    {
        Assert.Equal(new[] { 1, 2 },
            Sumando(new[] { 3, 2, 4 }, 6));
    }

    [Fact]
    public void Prueba3()
    {
        Assert.Equal(new[] { 0, 1 },
            Sumando(new[] { 3, 3 }, 6));
    }

    private int[] Sumando(int[] nums, int target)
    {
        var mago = new Dictionary<int, int>();
        for (var ox = 0; ox < nums.Length; ox++)
        {
            var actual = nums[ox];
            var arreglando = target - actual;
            if (mago.TryGetValue(arreglando, out var sinValor))
                return new[] { sinValor, ox };
            mago[actual] = ox;
        }

        return Array.Empty<int>();
    }
}