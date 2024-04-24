namespace Tests;

public class StackTests
{
    [Fact]
    public void Pop()
    {
        // LIFO
        var s = new Stack<string>();
        
        s.Push("A");
        s.Push("B");

        var actual = s.Pop();
        
        Assert.Equal("B", actual);
        Assert.Equal("A", s.Peek());
    }

    [Fact]
    public void Pop_Empty()
    {
        var s = new Stack<int>();
        
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }
}