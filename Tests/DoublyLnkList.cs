namespace Tests;

public class DoublyLnkList<T> : ILnkList<T>
{
    public static DoublyLnkList<T> From(params T[] values)
    {
        var list = new DoublyLnkList<T>();
        foreach (var value in values)
            list.Append(value);
        return list;
    }

    private DoublyLnkNode? _head;
    private DoublyLnkNode? _last;

    public DoublyLnkList()
    {
        _head = null;
        _last = null;
    }

    public void Prepend(T value)
    {
        if (_head == null)
        {
            _head = new DoublyLnkNode(value);
            return;
        }

        _head = new DoublyLnkNode(value, _head);
    }

    public void Append(T value)
    {
        var newValue = new DoublyLnkNode(value);
        if (_head == null)
        {
            _head = newValue;
            _last = newValue;
            return;
        }
            
        _last.Next = newValue;
        newValue.Prev = _last;
        _last = newValue;
    }

    public T First()
    {
        if (_head == null)
            throw new InvalidOperationException();
        
        return _head.Value;
    }

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

    public T Get(int index)
    {
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

    public IEnumerable<T> ToReversedEnumerable()
    {
        var result = new List<T>();
        
        var current = _last;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Prev;
        }

        return result;
    }

    public bool RemoveAt(int index)
    {
        if (index < 0)
            return false;

        if (_head == null)
            return false;

        if (index == 0)
        {
            if (_head.Next != null)
                _head.Next.Prev = null;
            
            _head = _head.Next;
            return true;
        }

        var currentIndex = 0;
        var current = _head;

        while (current != null)
        {
            if (currentIndex == index)
            {
                var prevNode = current.Prev;
                var nextNode = current.Next;

                if (prevNode != null)
                {
                    prevNode.Next = nextNode;
                }
                if (nextNode != null)
                {
                    nextNode.Prev = prevNode;
                }
                
                return true;
            }

            currentIndex++;
            current = current.Next;
        }

        return false;
    }

    public bool Remove(T value)
    {
        if (_head == null)
            return false;
    
        if (_head.ValueEquals(value))
        {
            if (_head.Next != null)
                _head.Next.Prev = null;
        
            _head = _head.Next;
            return true;
        }
    
        var current = _head;
        while (current.Next != null)
        {
            if (current.NextValueEquals(value))
            {
                if (current.Next.Next != null)
                    current.Next.Next.Prev= current;
            
                current.Next = current.Next.Next;
                return true;
            }
    
            current = current.Next;
        }
    
        return false;
    }
    

    private class DoublyLnkNode
    {
        public T Value { get; }
        
        public DoublyLnkNode? Prev { get; set; }
        public DoublyLnkNode? Next { get; set; }

        public DoublyLnkNode(T value, DoublyLnkNode? next = null, DoublyLnkNode? prev = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }

        public bool ValueEquals(T value) =>
            Value != null && Value.Equals(value);

        public bool NextValueEquals(T value) =>
            Next != null && Next.ValueEquals(value);
        
        public bool PrevValueEquals(T value) =>
            Prev != null && Prev.ValueEquals(value);

    }
}