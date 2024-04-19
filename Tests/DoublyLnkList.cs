namespace Tests;

public class DoublyLnkList<T> : ILnkList<T>
{
    private LnkNode? _head = null;
    private LnkNode? _last = null;
    
    public static DoublyLnkList<T> From(params T[] values)
    {
        throw new NotImplementedException();
    }

    public void Prepend(T value)
    {
        var node = new LnkNode(value);
        if(_head == null)
        {
            _head = new LnkNode(value);
            _last = _head;
        }
        //_head = new LnkNode(value, _head);
        node.Next = _head;
        _head = node;
        Count += 1;
    }

    public void Append(T value)
    {
        var node = new LnkNode(value);
        if(_last == null)
        {
            _head = node;
        }
        else
        {
            node.Previous = _last;
            _last.Next = node;
        }
        _last = node;
        // _last = new LnkNode(value, null, _last);
        Count += 1;
    }

    public T First()
    {
        if (_head == null)
            throw new InvalidOperationException();

        return _head.Value!;
    }

    public bool Any(Func<T, bool> compare)
    {
        var current = _head;
        while (current != null)
        {
            if (compare(current.Value!))
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

        var current = _head;
        int currentIndex = 0;
        while (current != null)
        {
            if(currentIndex == index)
            {
                return current.Value!;
            }
            currentIndex++;
            current = current.Next;
        }
        throw new IndexOutOfRangeException();
    }

    // O(1)
    public int Count = 0;

    public IEnumerable<T> ToEnumerable()
    {
        List<T> list = new List<T>();

        var current = _head;
        while (current != null)
        {
            list.Add(current.Value!);
            current = current.Next;
        }
        return list;
    }

    public IEnumerable<T> ToReversedEnumerable()
    {
        List<T> list = new List<T>();

        var current = _last;
        while(current != null)
        {
            list.Add(current.Value!);
            current = current.Previous;
        }
        return list;
    }

    public bool RemoveAt(int index)
    {
        if (index < 0)
            return false;

        var current = _head;
        var currentIndex = 0;

        while (current != null)
        {
            if (currentIndex == index)
            {
                Count--;
                return true;
            }
            currentIndex++;
            current = current.Next;
        }
        return false;
    }

    public bool Remove(T value)
    {
        var current = _head;
        if(_head.Value.Equals(value))
        {
            _head = _head.Next;
            Count--;
            return true;
        }
        if (_last.Value.Equals(value))
        {
            _last = _last.Previous;
            Count--;
            return true;
        }
        else
        {
            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    current.Previous = current.Next;
                    current.Next = current.Previous;

                    Count--;
                    return true;
                }
            }
            return false;
        }
    }

    public class LnkNode
    {
        public T? Value { get; set; }
        public LnkNode? Next { get; set; }
        public LnkNode? Previous { get; set; }

        public LnkNode(T? value, LnkNode? next = null, LnkNode? previous = null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}