using Implementations;

namespace Tests;

public class BinarySearchTreeNodeTests
{
    [Fact]
    public void Constructor()
    {
        var n = new BSTreeNode(10);
        
        Assert.Equal(10, n.Value);
        Assert.Null(n.Left);
        Assert.Null(n.Right);
    }

    [Fact]
    public void RepeatedValue()
    {
        var n = new BSTreeNode(10);

        n.Add(10);
        
        Assert.Null(n.Left);
        Assert.Null(n.Right);
    }

    [Fact]
    public void Add_Left()
    {
        var n = new BSTreeNode(10);
        
        n.Add(5);
        
        Assert.Null(n.Right);
        Assert.Equal(5, n.LeftValue);
    }
    
    [Fact]
    public void Add_Right()
    {
        var n = new BSTreeNode(10);
        
        n.Add(15);
        
        Assert.Null(n.Left);
        Assert.Equal(15, n.RightValue);
    }
    
    [Fact]
    public void Add_LeftIsNotNull()
    {
        var n = new BSTreeNode(10);
        
        n.Add(5);
        n.Add(2);
        
        Assert.Null(n.Right);

        var left = n.Left!;
        Assert.Null(left.Right);
        
        Assert.Equal(2, left.LeftValue);
    }
    
    [Fact]
    public void Add_RightIsNotNull()
    {
        var n = new BSTreeNode(10);
        
        n.Add(15);
        n.Add(20);
        
        Assert.Null(n.Left);

        var right = n.Right!;
        Assert.Null(right.Left);
        
        Assert.Equal(20, right.RightValue);
    }

    [Fact]
    public void Contains()
    {
        var n = new BSTreeNode(10);
        
        Assert.True(n.Contains(10));
    }
    
    [Fact]
    public void Contains_InLeft()
    {
        var n = new BSTreeNode(10);
        
        n.Add(5);
        
        Assert.True(n.Contains(5));
    }
    
    [Fact]
    public void Contains_InRight()
    {
        var n = new BSTreeNode(10);
        
        n.Add(15);
        
        Assert.True(n.Contains(15));
    }
    
    [Fact]
    public void Contains_InRightSubTree()
    {
        var n = new BSTreeNode(10);
        
        n.Add(15);
        n.Add(20);
        
        Assert.True(n.Contains(20));
    }
    
    [Fact]
    public void Contains_InLeftSubTree()
    {
        var n = new BSTreeNode(10);
        
        n.Add(5);
        n.Add(1);
        
        Assert.True(n.Contains(1));
    }
    
    [Fact]
    public void Contains_OneNode_NotFoundInLeft()
    {
        var n = new BSTreeNode(10);

        Assert.False(n.Contains(5));
    }
    
    [Fact]
    public void Contains_OneNode_NotFoundInRight()
    {
        var n = new BSTreeNode(10);

        Assert.False(n.Contains(15));
    }

    [Fact]
    public void Contains_Many()
    {
        var n = new BSTreeNode(10);
        n.Add(5);
        n.Add(15);
        n.Add(15);
        n.Add(1);
        n.Add(20);
        n.Add(30);
        n.Add(25);
        n.Add(50);
        
        Assert.True(n.Contains(50));
    }
    
    [Fact]
    public void Contains_NotFoundMany()
    {
        var n = new BSTreeNode(10);
        n.Add(5);
        n.Add(15);
        n.Add(1);
        n.Add(20);
        n.Add(20);
        
        Assert.False(n.Contains(50));
    }
}