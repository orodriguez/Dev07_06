using Implementations;

namespace AAD.Tests;

public class GraphTests
{
    [Fact]
    public void Paths_NodeNotFound()
    {
        var g = new Graph<string>();

        Assert.Empty(g.Paths("A", "B"));
    }

    [Fact]
    public void Paths_StartDoesNotExist()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        Assert.Empty(g.Paths("C", "B"));
    }

    [Fact]
    public void Paths_EndDoesNotExist()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        Assert.Empty(g.Paths("A", "C"));
    }

    [Fact]
    public void Paths_StartToStart()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        var path = Assert.Single(g.Paths("A", "A"));

        Assert.Equal(new[] { "A" }, path);
    }

    [Fact]
    public void Paths_OneSingleStepPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        var path = Assert.Single(g.Paths("A", "B"));

        Assert.Equal(new[] { "A", "B" }, path);
    }

    [Fact]
    public void Paths_One2StepPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");

        var path = Assert.Single(g.Paths("A", "C"));

        Assert.Equal(new[] { "A", "B", "C" }, path);
    }

    [Fact]
    public void Paths_TwoPaths()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("A", "C");

        var paths = g.Paths("A", "C");

        var expected = new[]
        {
            new[] { "A", "B", "C" }, 
            new[] { "A", "C" }
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void Paths_3StepsPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("C", "D");

        var paths = g.Paths("A", "D");

        var expected = new[]
        {
            new[] { "A", "B", "C", "D" }
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void Paths_Circular()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("C", "A");
        g.Add("C", "D");

        var paths = g.Paths("A", "D");

        var expected = new[]
        {
            new[] { "A", "B", "C", "D" }
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void Paths_Complex()
    {
        var g = new Graph<string>();
        g.Add("SD", "Villa Altagracia");
        g.Add("Villa Altagracia", "Bonao");
        g.Add("Bonao", "La Vega");
        g.Add("SD", "Yamasa");
        g.Add("Yamasa", "Bonao");
        g.Add("Yamasa", "Cotui");
        g.Add("Cotui", "La Vega");

        var paths = g.Paths("SD", "La Vega");

        var expected = new[]
        {
            new[] { "SD", "Villa Altagracia", "Bonao", "La Vega" },
            new[] { "SD", "Yamasa", "Bonao", "La Vega" },
            new[] { "SD", "Yamasa", "Cotui", "La Vega" },
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void ShortestPath()
    {
        var graph = new Graph<string>();
        graph.Add("A", "B");
        graph.Add("A", "C");
        graph.Add("B", "D");
        graph.Add("C", "E");
        graph.Add("D", "E");
        graph.Add("D", "F");
        graph.Add("E", "F");

        var shortestPath = graph.ShortestPath("A", "F");

        Assert.Equal(new[] { "A", "B", "D", "F" }, shortestPath);
    }
    
    [Fact]
    public void ShortestPath_SingleNode()
    {
        var graph = new Graph<string>();
        graph.Add("A", "A");

        var shortestPath = graph.ShortestPath("A", "A");

        var collection = shortestPath as string[] ?? shortestPath.ToArray();
        Assert.Single(collection);
        Assert.Equal("A", collection[0]);
    }
    
    [Fact]
    public void ShortestPath_Empty()
    {
        var graph = new Graph<string>();

        var shortestPath = graph.ShortestPath("A", "B");

        Assert.Empty(shortestPath);
    }
    
    [Fact]
    public void Paths_ShortestPath_Complex()
    {
        var g = new Graph<string>();
        g.Add("SD", "Villa Altagracia");
        g.Add("Villa Altagracia", "Bonao");
        g.Add("Bonao", "La Vega");
        g.Add("SD", "Yamasa");
        g.Add("Yamasa", "Bonao");
        g.Add("Yamasa", "Cotui");
        g.Add("Cotui", "La Vega");

        var paths = g.ShortestPath("SD", "Bonao");
        
        Assert.Equal(new[] { "SD", "Villa Altagracia", "Bonao" }, paths);
    }
}