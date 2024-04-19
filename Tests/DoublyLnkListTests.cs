namespace Tests;

public class DoublyLnkListTests : AbstractLnkListTests
{
    protected override ILnkList<T> CreateLinkedList<T>() => new DoublyLnkList<T>();
    protected override ILnkList<T> CreateLinkedList<T>(params T[] values) => DoublyLnkList<T>.From(values);

    [Fact]
    public void Last_One()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);

        Assert.Equal(1, ll.Last());
    }
    
    [Fact]
    public void Last_Two()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Append(2);

        Assert.Equal(2, ll.Last());
    }
    
    [Fact]
    public void Last_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<InvalidOperationException>(
            () => ll.Last());
    }

    [Fact]
    public void ToReversedEnumerable()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);
        
        Assert.Equal(new[] {3, 2, 1}, ll.ToReversedEnumerable());
    }
}