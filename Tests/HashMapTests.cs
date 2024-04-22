namespace Tests;

public class HashMapTests
{
    [Fact]
    public void ThreeElements_10Capacity()
    {
        var hashMap = new HashMap<string, int>(capacity: 10);
        
        hashMap.Add("Monday", 20);
        hashMap.Add("Wednesday", 23);
        hashMap.Add("Friday", 25);
        
        Assert.Equal(25, hashMap["Friday"]);
    }
    
    [Fact]
    public void Collision()
    {
        var hashMap = new HashMap<string, int>(capacity: 2);
        
        hashMap.Add("Monday", 20);
        hashMap.Add("Wednesday", 23);
        hashMap.Add("Friday", 25);
        
        Assert.Equal(20, hashMap["Monday"]);
        Assert.Equal(23, hashMap["Wednesday"]);
        Assert.Equal(25, hashMap["Friday"]);
    }
    
    [Fact]
    public void Chars()
    {
        var hashMap = new HashMap<char, int>(capacity: 2);
        
        hashMap.Add('M', 20);
        hashMap.Add('W', 23);
        hashMap.Add('F', 25);
        
        Assert.Equal(20, hashMap['M']);
        Assert.Equal(23, hashMap['W']);
        Assert.Equal(25, hashMap['F']);
    }
}