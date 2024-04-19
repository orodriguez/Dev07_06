using System.Collections;

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

    public int Count { get; private set; }

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
            _last = _head;
            Count++;
            return;
        }

        _head = new DoublyLnkNode(value, _head);

        Count++;
    }

    // O(1)
    public void Append(T value)
    {
        if (_head == null)
        {
            _head = new DoublyLnkNode(value);
            _last = _head;
            Count++;
            return;
        }

        _last = new DoublyLnkNode(value, next: null, previous: _last);
        Count++;
    }

    public T First()
    {
        throw new NotImplementedException();
    }

    public bool Any(Func<T, bool> compare)
    {
        throw new NotImplementedException();
    }

    public T this[int index] => throw new NotImplementedException();

    public T Get(int index)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> ToEnumerable()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<int> ToReversedEnumerable()
    {
        throw new NotImplementedException();
    }

    public bool RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T Last()
    {
        if (_last == null)
            throw new InvalidOperationException();
        
        return _last.Value;
    }

    private class DoublyLnkNode
    {
        public T Value { get; }
        public DoublyLnkNode? Next { get; set; }
        public DoublyLnkNode? Previous { get; private set; }

        public DoublyLnkNode(T value, 
            DoublyLnkNode? next = null,
            DoublyLnkNode? previous = null)
        {
            Value = value;
            Next = next;
            Previous = previous;
            
            if (next != null)
                next.Previous = this;

            if (previous != null)
                previous.Next = this;
        }
        
        public bool NextValueEquals(T value) =>
            Next != null && Next.ValueEquals(value);

        public bool ValueEquals(T value) =>
            Value != null && Value.Equals(value);

        public void AddAfter(T value) => 
            Next = new DoublyLnkNode(value, next: null, previous: this);
    }
}