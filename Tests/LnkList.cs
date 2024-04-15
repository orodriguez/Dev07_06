namespace Tests;

public class LnkList
{
    private LnkNode? _head;

    public LnkList() => 
        _head = null;

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

    // O(1)
    public int First()
    {
        if (_head == null)
            throw new InvalidOperationException();
        
        return _head.Value;
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