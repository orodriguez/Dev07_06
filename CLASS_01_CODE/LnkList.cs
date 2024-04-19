namespace Tests;

public class LnkList
{
    private LnkNode? _head;

    public LnkList() => 
        _head = null;


    // O(1)

    public void Prepend(int value)
    {
        if (_head == null)
        {
            _head = new LnkNode(value);
            return;
        }

        _head = new LnkNode(value, _head);
    }
    
    // O(n)

    public void Append(int value)
    {
        if (_head == null)
        {
            _head = new LnkNode(value);
            return;
        }

        var current = _head;
        while (current.Next != null) 
            current = current.Next;
        
        current.Next = new LnkNode(value);
    }

    // O(1)
    public int First()
    {
        if (_head == null)
            throw new InvalidOperationException();
        
        return _head.Value;
    }
    
    // O(?)
    public int Get(int index)
    {
        // Explicacion !
        /* Cuando llamamos el metodo get ! en line 14 del metodo GetByIndex() del
         LnKlistTest.CS, , obtenemos una exeption, que indica

        que este metodo Get aun no a sido implementado
        */ 
        /*Anteriormente teniamos esto
         throw new NotImplementedException();
       */ 
        
        //--  Procedemos a implementar -- 
        // Apuntamos a la cabeza, xD 
        var current = _head;
        // currentIndex para poder interar
        int currentIndex = 0;
        // Mientras no sea null
        while (current != null)
        {
            // Si el indice es igual al indice que buscamos
            if (currentIndex == index)
                // Devuelve el valor del nodo actual
                return current.Value;
            // Si, continuamos al siguiente nodo
            current = current.Next;
            // aumentamos en 1, para seguir iterando
            currentIndex++;
        }
        //Si no encontramos lo que buscamos, pues ya que xD 
        throw new IndexOutOfRangeException("Index out of range.");

    }

    // O(n)
    public int Count()
    {
        var result = 0;

        var current = _head;

        while (current != null)
        {
            result++;
            current = current.Next;
        }

        return result;
    }

    // O(n)

    public IEnumerable<int> ToEnumerable()
    {
        var result = new List<int>();
        
        var current = _head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }
        return result;
    }

    private class LnkNode
    {
        public int Value { get; }
        public LnkNode? Next { get; set; }

        public LnkNode(int value, LnkNode? next = null)
        {
            Value = value;
            Next = next;
        }
    }
}