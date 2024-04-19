namespace Tests;

public class DoublyLnkList<T> : ILnkList<T>
{
    private class Node
    {
        public T Value { get; }
        public Node? Previous { get; set; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count;

    public static DoublyLnkList<T> From(params T[] values)
    {
        var list = new DoublyLnkList<T>();
        foreach (var value in values)
        {
            list.Append(value);
        }
        return list;
    }

    public void Prepend(T value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        _count++;
    }

    public void Append(T value)
    {
        Node newNode = new Node(value);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
        _count++;
    }

    public T First()
    {
        if (_head == null)
            throw new InvalidOperationException("The list is empty.");
        return _head.Value;
    }

    public bool Any(Func<T, bool> compare)
    {
        Node? current = _head;
        while (current != null)
        {
            if (compare(current.Value))
                return true;
            current = current.Next;
        }
        return false;
    }

    public T this[int index]
    {
        get
        {
            return Get(index);
        }
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();

        Node? current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current!.Next;
        }
        return current!.Value;
    }

    public int Count()
    {
        return _count;
    }

    public IEnumerable<T> ToEnumerable()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public IEnumerable<T> ToReversedEnumerable()
    {
        Node? current = _tail;
        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            return false;

        Node? current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current!.Next;
        }

        if (current == _head)
        {
            _head = current!.Next;
        }
        else
        {
            current!.Previous!.Next = current.Next;
        }

        if (current == _tail)
        {
            _tail = current.Previous;
        }
        else
        {
            current.Next!.Previous = current.Previous;
        }

        _count--;
        return true;
    }

    public bool Remove(T value)
    {
        Node? current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                if (current == _head)
                {
                    _head = current.Next;
                    if (_head != null)
                        _head.Previous = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                }

                if (current == _tail)
                {
                    _tail = current.Previous;
                    if (_tail != null)
                        _tail.Next = null;
                }
                else
                {
                    current.Next!.Previous = current.Previous;
                }

                _count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }
}