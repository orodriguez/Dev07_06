using Implementations;

namespace Tests;

public class TreeNodeTests
{
    [Fact]
    public void Count()
    {
        var tree = new Tree<string>();
        
        Assert.Equal(0, tree.Count());
    }
    
    [Fact]
    public void Count_SingleNode()
    {
        var tree = new Tree<string>("SuperMarket");

        Assert.Equal(1, tree.Count());
    }
    
    [Fact]
    public void Count_WithLeaf()
    {
        var tree = new Tree<string>("SuperMarket");

        tree.Add("Vegetables");

        Assert.Equal(2, tree.Count());
    }
    
    [Fact]
    public void Count_SubTree()
    {
        var tree = new Tree<string>("SuperMarket");

        tree.Add("Vegetables", node => 
            node.Add("Tomato"));

        Assert.Equal(3, tree.Count());
    }
    
    [Fact]
    public void Count_ManyNodes()
    {
        var tree = new Tree<string>("SuperMarket");

        tree
            .Add("Vegetables", vegetables =>
            {
                vegetables.Add("Tomato");
                vegetables.Add("Lettuce");
            })
            .Add("PersonalCare", personalCare =>
            {
                personalCare.Add("Shampoo", shampoo => 
                    shampoo.Add("HeadAndShoulders"));
            });

        Assert.Equal(7, tree.Count());
    }

    [Fact]
    public void TraversePreorder()
    {
        var tree = new Tree<string>("SuperMarket");

        tree
            .Add("Vegetables", vegetables =>
            {
                vegetables.Add("Tomato");
                vegetables.Add("Lettuce");
            });

        var result = new List<string>();

        tree.TraversePreOrder(value => result.Add(value));

        Assert.Equal(new[] { "SuperMarket", "Vegetables", "Tomato", "Lettuce" },
            result);
    }
}