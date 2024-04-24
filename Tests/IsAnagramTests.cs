namespace Tests;

public class IsAnagramTests
{
    [Fact]
    public void IsAnagram_True()
    {
        var first = "anagram";
        var second = "nagaram";
        Assert.True(IsAnagram(first, second));
    }
    
    [Fact]
    public void IsAnagram_False()
    {
        var first = "car";
        var second = "rat";
        Assert.False(IsAnagram(first, second));
    }
    
    [Fact]
    public void IsAnagram_Caps()
    {
        var first = "NacioNaLista ";
        var second = "altisonancia";
        Assert.False(IsAnagram(first, second));
    }
    
    [Fact]
    public void IsAnagram_LengthDiff()
    {
        var first = "carro";
        var second = "rat";
        Assert.False(IsAnagram(first, second));
    }


    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;
        
        var myDictionary = new Dictionary<char, int>();

        foreach (var character in s)
        {
            if (myDictionary.ContainsKey(character))
                myDictionary[character]++;
            else
                myDictionary[character] = 1;
        }

        foreach (var character in t)
        {
            if (myDictionary.ContainsKey(character))
                myDictionary[character]--;
            else
                return false;
        }

        
        return myDictionary.Values.All(v => v == 0);

    }
}