namespace Tests
{
    public class DoublyLnkList<T> : ILnkList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }
            public Node? Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }

        private Node? _head;
        private Node? _last;
        private int _count;

        public DoublyLnkList()
        {
            _head = null;
            _last = null;
            _count = 0;
        }

        public static DoublyLnkList<T> From(params T[] values)
        {
            var newList = new DoublyLnkList<T>();
            foreach (var value in values)
            {
                newList.Append(value);
            }
            return newList;
        }

        public void Prepend(T value)
        {
            var newNode = new Node(value);
            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
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
            var newNode = new Node(value);
            if (_last == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Previous = _last;
                _last.Next = newNode;
                _last = newNode;
            }
            _count++;
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

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new InvalidOperationException();
                }
                current = current.Next;
            }

            if (current == null)
            {
                throw new InvalidOperationException();
            }

            return current.Value;
        }

        public int Count()
        {
            return _count;
        }

        public IEnumerable<T> ToEnumerable()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerable<T> ToReversedEnumerable()
        {
            var current = _last;
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

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new InvalidOperationException();
                }
                current = current.Next;
            }

            if (current == null)
            {
                throw new InvalidOperationException();
            }

            if (current == _head)
            {
                _head = current.Next;
                if (_head != null)
                    _head.Previous = null;
            }
            else if (current == _last)
            {
                _last = current.Previous;
                if (_last != null)
                    _last.Next = null;
            }
            else
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
            }

            _count--;
            return true;
        }

        public bool Remove(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    if (current == _head)
                        _head = current.Next;

                    if (current == _last)
                        _last = current.Previous;

                    if (current.Previous != null)
                        current.Previous.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;

                    _count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public T this[int index]
        {
            get { return Get(index); }
        }
    }
}
