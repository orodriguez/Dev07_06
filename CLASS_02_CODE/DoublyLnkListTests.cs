namespace Tests;

public class DoublyLnkListTests
{
   
    [Fact]
    // Es O(1) por que accede directamente al indice del elemento
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
    /* Es O(n) ya que en el peor de los casos recorreria el final
    de la lista, para encontrar el elemento.
    */
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
    /* Es O(n) ya que en el peor de los casos recorreria el final
    de la lista, para encontrar el elemento.
    */
    public void GetByIndex_NotFound()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(1));
    }
   
    [Fact]
    /* Es O(1) ya que especifica lo que busca sin importar el tamaño
    de la lista, este metodo busca en una lista vacia por lo tanto
    en el metodo   public T Get(int index){}
    hare un  throw new ArgumentOutOfRangeException por que no esta
    dentro del rango.
   */
    
    public void GetByIndex_OutOfRange_Negative()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(-1));
    }

    
    [Fact]
    /* Es O(n) este metodo itera la lista hasta encontrar el elemento
     en el indice indicado, lo cual en el peor de los casos si el indice
     es mayor al numero de elementos de la lista, tendra que atraversarla
    completa.
   */
    public void GetByIndex_OutOfRange_GreaterThanCount()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(10);

        Assert.Throws<IndexOutOfRangeException>(
            () => ll.Get(2));
    }
  
    //************************************************************

    
    //-**************************-> ANY<---****************************
    [Fact]
    /* Es O(n) este metodo itera una lista vacia donde se busca a el elemento "a"
      Assert.False asegura que retorne falso por que la lista esta vacia por lo tanto
      "a" no existe en ella.
  */
    // Any(Func<T, bool> compare){}
    public void Any_NotFound()
    {
        var ll = new DoublyLnkList<char>();

        Assert.False(ll.Any(value => value == 'a'));
    }
    
    
    /* Es O(1) en este ocacion tenemos una lista de characters, a,b,c you and me xD
     donde si encontramos el char 'b', retornamos true, es Big O(1) por que tenemos un
     apuntador directo 'b' y esta en la lista.
    */
    [Fact]
    // Any(Func<T, bool> compare){}
    public void Any_Exists()
    {
        var ll = new DoublyLnkList<char>();

        ll.Append('a');
        ll.Append('b');
        ll.Append('c');

        Assert.True(ll.Any(value => value == 'b'));
    }
    
    //-*********************-> ANY<---****************************

    
    //-*********************-> First<---****************************
    [Fact]
    // First(){}
    // Prepend(T value){}
    /* Es O(1) por que añade el elemento al principio de la lista
     * lo cual indica que si la lista es gigante, no importaria por que ya esta en
     * la secuencia inicial
     */
    
    public void First_AfterPrepend()
    {
        var ll = new DoublyLnkList<int>();

        ll.Prepend(30);

        Assert.Equal(30, ll.First());
    }

    /* Es O(1) por que despues de agregar a 30 40 y 50 a la lista ll
     podemos ver que busca a 30, lo cual esta en la primera secuencia.
     
     */
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
    /* Es O(1) en este caso tenemos una lista vacia, y el Assert nos arroja 
     un Throws<InvalidOperationException si en ll.First()); no se encuentra 
     el primer elemento  First_Empty() xD 
   */
    
    public void First_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Throws<InvalidOperationException>(() => ll.First());
    }
    
    //-*********************-> First<---****************************

    
    //-*********************-> Count<---****************************
    [Fact]
    /* En este caso no es relevante en performance, ya que el metodo devuelve el conteo
     total que existe en la lista, en este caso esta vacia , 
     por lo tanto y de igual forma Assert.Equal espera que este vacia 
     y es justo como esta la lista
   */
    public void Count()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(0, ll.Count());
    }

    [Fact]
    /*  De igual forma, en este caso no es relevante a performance
    ya que a la lista se le hace un  Prepend(10) lo cual indica que tiene un elemento, 
    y por lo tanto si el total de elemento contados es 1 segun 
     Assert.Equal(1, ll.Count()); el test pasa. Se murio naciendo XD lol xD
    */
    public void Count_OneElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Prepend(10);

        Assert.Equal(1, ll.Count());
    }

    [Fact]
    
    /* De igual forma, en este caso no es relevante a performance
     * ya que aunque se agregen 3 elementos  Assert.Equal espera 3
     * elementos y estos son los unicos agregados y por ello el count es 3
     * justo lo que espera y termina.
     * 
    */
    public void Count_ManyElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(10);
        ll.Append(20);
        ll.Append(30);

        Assert.Equal(3, ll.Count());
    }
//-*********************-> Count<---****************************


//-*********************-> ToEnumerable<---****************************
    [Fact]
    /* O(1) en este caso, ToEnumerable retorna vacio, por lo tanto 
    ll esta vacio   Assert.Equal se asegura de eso. 
    por lo tanto no itera en nada, ya que retorna que esta vacio el ToEnumerable
    */ 
    public void ToEnumerable_Empty()
    {
        var ll = new DoublyLnkList<int>();

        Assert.Equal(Array.Empty<int>(), ll.ToEnumerable());
    }

    [Fact]
    /* O(1) en este caso, ToEnumerable retorna vacio, por lo tanto
   ll esta vacio   Assert.Equal se asegura de eso.
   por lo tanto no itera en nada, ya que retorna que esta vacio el ToEnumerable
   */ 
    public void ToEnumerable_OneElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);

        Assert.Equal(new[] { 1 }, ll.ToEnumerable());
    }

    [Fact]
    /*
     * Es O(n) ya que ToEnumerable itera sobre cada node y saca su valor
     * por lo tanto la cantidad de elemento es proporcional
     * Y como de igual forma tiene que comparar el array debe de iterar
     * para ofrecer el resultado de la comparacion.
     */
    
    public void ToEnumerable_ManyElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Append(2);
        ll.Append(3);

        Assert.Equal(new[] { 1, 2, 3 }, ll.ToEnumerable());
    }
    
    [Fact]
    /*  O(n) ya que itera los elementos de la lista
     emepezando desde el tail y nos dice cada valor en reversa 
     uno por uno y con  Assert.Equal(new[] { 3, 2, 1 } confirmamos 
     que sea asi claro esta, segun ll.Append(1); 2 y 3 xD
     
     */
    public void ToReversedEnumerable_ManyElement()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Append(2);
        ll.Append(3);

        Assert.Equal(new[] { 3, 2, 1 }, ll.ToReversedEnumerable());
    }

    [Fact]
    /*
     *Es O(n) ToEnumerable() ya que desde la head hasta la tail
     * itera cada elemento obteniendo su valor, por lo tanto
     * Pero Prepend es 0(1) por que apunta a lo que desea hacer
     */
    public void ToEnumerable_Prepend()
    {
        var ll = new DoublyLnkList<int>();

        ll.Append(1);
        ll.Prepend(2);

        Assert.Equal(new[] { 2, 1 }, ll.ToEnumerable());
    }
//-*********************-> ToEnumerable <---****************************

//-*********************->RemoveAt <---****************************
    [Fact]
    /*
     *O(1) como tiene un apuntador que es el indice 0
     *  y en este caso Assert.False(list.RemoveAt(0));
     * se encarga de que si no logra borrar
     * returne falso, es por lo cual es super rapido.
     */
    public void RemoveAt_Empty()
    {
        var list = new DoublyLnkList<string>();

        Assert.False(list.RemoveAt(0));
    }

    [Fact]
    /*
     * O(n)  ya que debemos de recorrer la lista buscando
     * el indice que deseamos borrar At(x gran numero)
     * en el peor de los casos
     * pero en casos donde se tenga que remover la cabeza y la cola
     * seria o(1) por que solo requiere actualizar las referencias
     * de heand and tail
     * 
     */
    public void RemoveAt_Many()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.RemoveAt(1));

        Assert.Equal(new[] { "a", "c" }, list.ToEnumerable());
    }

    [Fact]
    /*
     * seria o(1) por que solo requiere actualizar las referencias
     * de tail and tail xD, head and tail 
     */
    public void RemoveAt_Last()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.RemoveAt(2));

        Assert.Equal(new[] { "a", "b" }, list.ToEnumerable());
    }
    
    [Fact]
    /*
     * seria o(1) por que solo requiere actualizar las referencias
     * de  tail and tail xD, head and tail 
     */
    public void RemoveAt_First()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.RemoveAt(0));

        Assert.Equal(new[] { "b", "c" }, list.ToEnumerable());
    }

    [Fact]
    /*
     * Es O(n) por que debe de atravesar la lista completa en el peor
     * caso, pero en este suele ser 0(1) por que mantenemos referencia al indice
     */
    public void RemoveAt_NotFound()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.False(list.RemoveAt(3));

        Assert.Equal(new[] { "a", "b", "c" }, list.ToEnumerable());
    }
    
    
    

    [Fact]
    
    /*
     *  Es O(1) ya que el indice es negativo, los cual esta fuera de rango,
     * entonces el metodo retorna sin tener que recorrer nada.
     * 
     */
    public void RemoveAt_NegativeIndex()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.False(list.RemoveAt(-1));

        Assert.Equal(new[] { "a", "b", "c" }, list.ToEnumerable());
    }

    //-*********************-> RemoveAt <---****************************
    
    //-*********************-> Remove<---****************************
    [Fact]
    /*
     *Es O(1) ya que intenta eliminar un elemento que no existe,
     * lo cual es siempre constante en tiempo.
     * 
     */
    public void Remove_Empty()
    {
        var list = new DoublyLnkList<string>();

        Assert.False(list.Remove("a"));
    }

    [Fact]
    /*
     *Es O(n) en el peor de los casos Remove tiene que atravesar la lista completa
     * para encontrar lo que removera, lo cual es relativo a lo largo de la lista
     * 
     * 
     */
    public void Remove_FromMany()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.Remove("b"));

        Assert.Equal(new[] { "a", "c" }, list.ToEnumerable());
    }

    [Fact]
    /*
     * es  O(n) ya que itera la lista completa, aunque no encuentre el elemento a borrar
     */
    public void Remove_NotFound()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.False(list.Remove("d"));

        Assert.Equal(new[] { "a", "b", "c" }, list.ToEnumerable());
    }
    
    [Fact]
    /*
     *  O(n) recorre la lista completa, y n es largo de la misma,
     * hasta llegar a el ultimo.
     * 
     */
    public void Remove_Last()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.Remove("c"));

        Assert.Equal(new[] { "a", "b" }, list.ToEnumerable());
    }
    
    [Fact]
    /* 
     *es O(1) ya que busca desde el head y es firts, 
     */
    public void Remove_First()
    {
        var list = DoublyLnkList<string>.From("a", "b", "c");

        Assert.True(list.Remove("a"));

        Assert.Equal(new[] { "b", "c" }, list.ToEnumerable());
    }
    
    //-*********************-> Remove <---****************************
}