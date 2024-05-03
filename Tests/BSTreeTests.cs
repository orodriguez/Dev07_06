using Implementations;

namespace Tests;

public class BSTreeTests
{
    [Fact]
    public void Add_Empty()
    {
        var t = new BSTree();
        t.Add(20);
        
        Assert.Equal(1, t.Count());
        Assert.True(t.Contains(20));
    }
    
    [Fact]
    public void Add_HasRoot()
    {
        var t = new BSTree();
        t.Add(20);
        t.Add(25);
        
        Assert.Equal(2, t.Count());
        Assert.True(t.Contains(25));
    }
    
    [Fact]
    public void Count_Empty()
    {
        var t = new BSTree();
        
        Assert.Equal(0, t.Count());
    }
    
    [Fact]
    public void Count_Repeated()
    {
        var t = new BSTree();
        t.Add(10);
        t.Add(10);
        
        Assert.Equal(1, t.Count());
    }
    
    [Fact]
    public void Count_Two()
    {
        var t = new BSTree();
        t.Add(10);
        t.Add(12);
        
        Assert.Equal(2, t.Count());
    }
    
    [Fact]
    public void Contains_Empty()
    {
        var t = new BSTree();
        
        Assert.False(t.Contains(10));
    }
    
    [Fact]
    public void Contains_One()
    {
        var t = new BSTree();
        t.Add(10);
        
        Assert.True(t.Contains(10));
    }

    [Fact]
    public void Delete()
    {
        var t = new BSTree();

        t.Delete(10);
        
        Assert.Equal(0, t.Count());
    }
    
    [Fact]
    public void Delete_OneNode()
    {
        var t = new BSTree();
        t.Add(10);
        t.Delete(10);
        
        Assert.Equal(0, t.Count());
    }
    [Fact]
    public void Copy_Into_Empty()
    {
        var t = new BSTree();
        t.Add(20);
        t.Add(25);
        t.Add(30);
        t.Add(5);
        t.Add(22);

        var empty = new BSTree();
        t.Copy(empty);

        Assert.Equal(t.Count(), empty.Count());
        Assert.True(empty.Contains(20));
        Assert.True(empty.Contains(25));
        Assert.True(empty.Contains(30));
        Assert.True(empty.Contains(5));
        Assert.True(empty.Contains(22));
    }
}