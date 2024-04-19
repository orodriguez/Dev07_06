using System.Globalization;

namespace Tests;

public class DoublyLnkList<T> : ILnkList<T>
{
    public static DoublyLnkList<T> From(params T[] values)
    {
        var list = new DoublyLnkList<T>();
        foreach ( var v in values )
            list.Append(v);
        return list;
    }

    private LnkNode? _head;
    private LnkNode? _tail;

    public DoublyLnkList()
    {
        _head = null;
        _tail = null;
    }


    public void Prepend(T value)
    {
        if( _head == null)
        {
            _head= new LnkNode(value);
            _tail = _head;
            return;
        }
        _head.Previous = new LnkNode(value) { Next = _head };
        _head = _head.Previous;
    }

    public void Append(T value)
    {
        if (_tail == null)
        {
            _head = new LnkNode(value);
            _tail = _head;
            return;
        }
        var last = _tail;
        last.Next = new LnkNode(value) { Previous = last };
        _tail = last.Next;
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
        if (_head == null)
            throw new IndexOutOfRangeException();

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

        var current = _tail;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Previous;
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
            _head = _head.Next;
            return true;
        }

        var currentIndex = 0;
        var current = _head;

        while (current.Next != null)
        {
            if (currentIndex == index - 1)
            {
                var nextNode = current.Next;
                current.Next = nextNode.Next;
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
            _head = _head.Next;
            return true;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.NextValueEquals(value))
            {
                current.Next = current.Next.Next;
                return true;
            }

            current = current.Next;
        }

        return false;
    }
    
    private class LnkNode
    {
        public T Value { get; }
        public LnkNode? Previous { get; set; }
        public LnkNode? Next { get; set; }
        
        public LnkNode(T value, LnkNode? previous = null, LnkNode? next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
        
        public bool ValueEquals(T value) =>
            Value != null && Value.Equals(value);
        public bool NextValueEquals(T value) =>
            Next != null && Next.ValueEquals(value);
        public bool PreviousValueEquals(T value) =>
            Previous != null && Previous.ValueEquals(value);
    }
}