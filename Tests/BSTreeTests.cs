using Implementations;

namespace Tests;
// Name 'BSTreeTests' does not match rule 'Types and namespaces'. Suggested name is 'BsTreeTests'
// public class BSTreeTests
public class BsTreeTests
{
    [Fact]
    public void Add_Empty()
    {
        var t = new BsTree();
        t.Add(20);
        
        Assert.Equal(1, t.Count());
        Assert.True(t.Contains(20));
    }
    
    [Fact]
    public void Add_HasRoot()
    {
        var t = new BsTree();
        t.Add(20);
        t.Add(25);
        
        Assert.Equal(2, t.Count());
        Assert.True(t.Contains(25));
    }
    
    [Fact]
    public void Count_Empty()
    {
        var t = new BsTree();
        
        Assert.Equal(0, t.Count());
    }
    
    [Fact]
    public void Count_Repeated()
    {
        var t = new BsTree();
        t.Add(10);
        t.Add(10);
        
        Assert.Equal(1, t.Count());
    }
    
    [Fact]
    public void Count_Two()
    {
        var t = new BsTree();
        t.Add(10);
        t.Add(12);
        
        Assert.Equal(2, t.Count());
    }
    
    [Fact]
    public void Contains_Empty()
    {
        var t = new BsTree();
        
        Assert.False(t.Contains(10));
    }
    
    [Fact]
    public void Contains_One()
    {
        var t = new BsTree();
        t.Add(10);
        
        Assert.True(t.Contains(10));
    }

    [Fact]
    public void Delete()
    {
        var t = new BsTree();

        t.Delete(10);
        
        Assert.Equal(0, t.Count());
    }
    
    [Fact]
    public void Delete_OneNode()
    {
        var t = new BsTree();
        t.Add(10);
        t.Delete(10);
        
        Assert.Equal(0, t.Count());
    }
}