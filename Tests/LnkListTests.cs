namespace Tests;

public class LnkListTests
{
    [Fact]
    public void First_AfterPrepend()
    {
        var ll = new LnkList();

        ll.Prepend(30);

        Assert.Equal(30, ll.First());
    }

    [Fact]
    public void First_Empty()
    {
        var ll = new LnkList();

        Assert.Throws<InvalidOperationException>(() => ll.First());
    }

    [Fact]
    public void ToEnumerable_Empty()
    {
        var ll = new LnkList();
        
        Assert.Equal(Array.Empty<int>(), ll.ToEnumerable());
    }

    [Fact]
    public void ToEnumerable_OneElement()
    {
        var ll = new LnkList();

        ll.Append(1);

        Assert.Equal(new[] { 1 }, ll.ToEnumerable());
    }
    
    [Fact]
    public void ToEnumerable_ManyElement()
    {
        var ll = new LnkList();

        ll.Append(1);
        ll.Append(2);
        ll.Append(3);

        Assert.Equal(new[] { 1, 2, 3 }, ll.ToEnumerable());
    }
    
    [Fact]
    public void ToEnumerable_Prepend()
    {
        var ll = new LnkList();

        ll.Append(1);
        ll.Prepend(2);

        Assert.Equal(new[] { 2, 1 }, ll.ToEnumerable());
    }

    [Fact]
    public void Count()
    {
        var ll = new LnkList();

        Assert.Equal(0, ll.Count());
    }

    [Fact]
    public void Count_OneElement()
    {
        var ll = new LnkList();

        ll.Prepend(10);

        Assert.Equal(1, ll.Count());
    }
    
    [Fact]
    public void Count_ManyElement()
    {
        var ll = new LnkList();

        ll.Append(10);
        ll.Append(20);
        ll.Append(30);

        Assert.Equal(3, ll.Count());
    }
}