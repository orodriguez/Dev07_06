namespace Tests;

public class DoublyLnkListTests : AbstractLnkListTests
{
    protected override ILnkList<T> CreateLinkedList<T>() => new DoublyLnkList<T>();
    protected override ILnkList<T> CreateLinkedList<T>(params T[] values) => DoublyLnkList<T>.From(values);

    [Fact]
    public void ToReversedEnumerable()
    {
        var ll = DoublyLnkList<int>.From(1, 2, 3);
        
        Assert.Equal(new[] {3, 2, 1}, ll.ToReversedEnumerable());
    }
}