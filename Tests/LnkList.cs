namespace Tests;

public class LnkList<T>
{
    private LnkNode? _head;

    public LnkList() => 
        _head = null;

    // O(1)

    public void Prepend(T value)
    {
        if (_head == null)
        {
            _head = new LnkNode(value);
            return;
        }

        _head = new LnkNode(value, _head);
    }


    // O(n)

    public void Append(T value)
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
    public T First()
    {
        if (_head == null)
            throw new InvalidOperationException();
        
        return _head.Value;
    }

    // O(n)
    public bool Any(Func<T, bool> compare)
    {
        var current = _head;
        while (current != null)
        {
            if (compare(current.Value))
                return true;
            
            current = current.Next;
        }
        return false;
    }

    public T this[int index] => Get(index);

    // O(n)
    public T Get(int index)
    {
        // Ω(1)
        if (_head == null)
            throw new IndexOutOfRangeException();
        
        // Ω(1)
        if (index < 0)
            throw new IndexOutOfRangeException();
        
        var currentIndex = 0;
        var current = _head;
        while (current != null)
        {
            if (currentIndex == index)
                return current.Value;
            
            currentIndex++;
            current = current.Next;
        }

        throw new IndexOutOfRangeException();
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


    public IEnumerable<T> ToEnumerable()
    {
        var result = new List<T>();
        
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
        public T Value { get; }
        public LnkNode? Next { get; set; }

        public LnkNode(T value, LnkNode? next = null)
        {
            Value = value;
            Next = next;
        }
    }
}