namespace Tests;

public class LnkListTests
{
    [Fact]
    public void GetByIndex()
    {
        var ll = new LnkList();

        ll.Append(10);
        ll.Append(20);
        ll.Append(30);
        
        var result = ll.Get(1);
        /* El Valor a comparar, no es correcto
      No esta dentro de la LinkedList de nombre ll
      2 no corresponde a 10,20,30 por lo tanto no es esperado(equal).
      .Get(1) apunta a el elemento 1(20) dentro de ll que tiene 10(0), 20(1) (30)
      por lo tanto deberia de ser 20 como valor esperado
      en .Equal(20).
      */
        Assert.Equal(20, result);
    }
    
    [Fact]
    public void GetByIndex_NotFound()
    {
        var ll = new LnkList();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(1));
    }

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
}