namespace Tests;

public class DoublyLnkListTests
{
    [Fact]
    public void GetByIndex_UsingIndexer()
    {
        var ll = new DoublyLnkList<string>();

        ll.Append("a");
        ll.Append("b");
        ll.Append("c");

        var result = ll[1];

        Assert.Equal("b", result);
    }

    [Fact]
    public void GetByIndex()
    {
        var ll = new DoublyLnkList<string>();

        ll.Append("a");
        ll.Append("b");
        ll.Append("c");

        var result = ll.Get(1);

        Assert.Equal("b", result);
    }

    [Fact]
    public void GetByIndex_NotFound()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(1));
    }

    [Fact]
    public void GetByIndex_OutOfRange_Negative()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(-1));
    }

    [Fact]
    public void GetByIndex_OutOfRange_GreaterThanCount()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(10);

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(2));
    }

    [Fact]
    public void Any_NotFound()
    {
        var ll = new DoublyLnkList<char>();

        Assert.False(ll.Any(value => value == 'a'));
    }

    [Fact]
    public void Any_Exists()
    {
        var ll = new DoublyLnkList<char>();

        ll.Append('a');
        ll.Append('b');
        ll.Append('c');

        Assert.True(ll.Any(value => value == 'b'));
    }

    [Fact]
    public void First_AfterPrepend()
    {
        var ll = new DoublyLnkList<int>();

        ll.Prepend(30);

        Assert.Equal(30, ll.First());
    }

    [Fact]
    public void First_FromMany()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(30);
        ll.Append(40);
        ll.Append(50);

        Assert.Equal(30, ll.First());
    }

    [Fact]
    public void First_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<InvalidOperationException>(() => ll.First());
    }

    [Fact]
    public void Count()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(0, ll.Count());
    }

    [Fact]
    public void Count_OneElement()
    {
        var ll = new DoublyLnkList<int>();
        ll.Prepend(10);

        Assert.Equal(1, ll.Count());
    }

    [Fact]
    public void Count_ManyElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(10);
        ll.Append(20);
        ll.Append(30);

        Assert.Equal(3, ll.Count());
    }

    [Fact]
    public void ToEnumerable_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(Array.Empty<int>(), ll.ToEnumerable());
    }

    [Fact]
    public void ToEnumerable_OneElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);

        Assert.Equal(new[] { 1 }, ll.ToEnumerable());
    }

    [Fact]
    public void ToEnumerable_ManyElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Append(2);
        ll.Append(3);

        Assert.Equal(new[] { 1, 2, 3 }, ll.ToEnumerable());
    }
    
    [Fact]
    public void ToReversedEnumerable_ManyElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Append(2);
        ll.Append(3);

        Assert.Equal(new[] { 3, 2, 1 }, ll.ToReversedEnumerable());
    }

    [Fact]
    public void ToEnumerable_Prepend()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Prepend(2);

        Assert.Equal(new[] { 2, 1 }, ll.ToEnumerable());
    }

    [Fact]
    public void RemoveAt_Empty()
    {
        var list = new DoublyLnkList<string>();

        Assert.False(list.RemoveAt(0));
    }

    [Fact]
    public void RemoveAt_Many()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.RemoveAt(1));

        Assert.Equal(new[] { "a", "c" }, list.ToEnumerable());
    }

    [Fact]
    public void RemoveAt_Last()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.RemoveAt(2));

        Assert.Equal(new[] { "a", "b" }, list.ToEnumerable());
    }
    
    [Fact]
    public void RemoveAt_First()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.RemoveAt(0));

        Assert.Equal(new[] { "b", "c" }, list.ToEnumerable());
    }

    [Fact]
    public void RemoveAt_NotFound()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.False(list.RemoveAt(3));

        Assert.Equal(new[] { "a", "b", "c" }, list.ToEnumerable());
    }

    [Fact]
    public void RemoveAt_NegativeIndex()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.False(list.RemoveAt(-1));

        Assert.Equal(new[] { "a", "b", "c" }, list.ToEnumerable());
    }

    [Fact]
    public void Remove_Empty()
    {
        var list = new DoublyLnkList<string>();

        Assert.False(list.Remove("a"));
    }

    [Fact]
    public void Remove_FromMany()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.Remove("b"));

        Assert.Equal(new[] { "a", "c" }, list.ToEnumerable());
    }

    [Fact]
    public void Remove_NotFound()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.False(list.Remove("d"));

        Assert.Equal(new[] { "a", "b", "c" }, list.ToEnumerable());
    }
    
    [Fact]
    public void Remove_Last()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.Remove("c"));

        Assert.Equal(new[] { "a", "b" }, list.ToEnumerable());
    }
    
    [Fact]
    public void Remove_First()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.Remove("a"));

        Assert.Equal(new[] { "b", "c" }, list.ToEnumerable());
    }
}