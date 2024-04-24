namespace Tests;

public class ValidAnagramTest
{
    [Fact]
    public void Test1()
    {
        Assert.True(IsAnagram("anagram", "nagaram"));
    }

    [Fact]
    public void Test2()
    {
        Assert.False(IsAnagram("rat", "car"));
    }
    
    [Fact]
    public void Test3()
    {
        Assert.False(IsAnagram("amar gana", "anagrama"));
    }

    private bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> charFrecuency = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (charFrecuency.ContainsKey(c))
                charFrecuency[c]++;
            else
                charFrecuency[c] = 1;
        }

        foreach (var c in t)
        {
            if (!charFrecuency.ContainsKey(c))
                return false;

            charFrecuency[c]--;

            if (charFrecuency[c] == 0)
                charFrecuency.Remove(c);
        }
        return true;
    }
}