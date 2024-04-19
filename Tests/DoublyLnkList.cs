using System.Text.RegularExpressions;

namespace Tests
{
    public class DoublyLnkList<T> : ILnkList<T>
    {
        private class LnkNode
        {
            public T Value { get; }
            public LnkNode? Next { get; set; }
            public LnkNode? Preview { get; set; }

            public LnkNode(T value, LnkNode? next = null, LnkNode? preview = null)
            {
                Value = value;
                Next = next;
                Preview = preview;
            }

            public bool NextValueEquals(T value) =>
                Next != null && Next.ValueEquals(value);

            public bool ValueEquals(T value) =>
                Value != null && Value.Equals(value);
        }

        private LnkNode? _head;
        private LnkNode? _last;
        private int _count;

        public static DoublyLnkList<T> From(params T[] values)
        {
            var list = new DoublyLnkList<T>();
            foreach (var value in values)
                list.Append(value);
            return list;
        }

        public void Prepend(T value)
        {
            var newNode = new LnkNode(value);
            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Preview = newNode;
                _head = newNode;
            }
            _count++;
        }


        public void Append(T value)
        {
            var newNode = new LnkNode(value);
            if (_head == null)
            {
                _head = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Preview = _last;
                _last!.Next = newNode;
                _last = newNode;
            }
            _count++;
        }



        public T First()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            return _head.Value;
        }



        public bool Any(Func<T, bool> compare)
        {
            var current = _head;
            while (current != null)
            {
                if (compare(current.Value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }




        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException("Índice fuera de rango.");
                }
                LnkNode current = _head!;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }
                return current.Value;
            }
        }



        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            var current = _head;
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

            while (current != null)
            {
                list.Add(current.Value!);
                current = current.Preview;
            }
            return list;
        }



        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                return false;
            }

            if (index == 0)
            {
                _head = _head!.Next;
                if (_head != null)
                {
                    _head.Preview = null;
                }
                else
                {
                    _last = null;
                }
            }
            else if (index == _count - 1)
            {
                _last = _last!.Preview;
                _last!.Next = null;
            }
            else
            {
                LnkNode current = _head!;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next!;
                }
                current.Next = current.Next!.Next;
                current.Next!.Preview = current;
            }

            _count--;
            return true;
        }




        public bool Remove(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    if (current == _head)
                    {
                        _head = _head!.Next;
                        if (_head != null)
                        {
                            _head.Preview = null;
                        }
                        else
                        {
                            _last = null;
                        }
                    }
                    else if (current == _last)
                    {
                        _last = _last!.Preview;
                        _last!.Next = null;
                    }
                    else
                    {
                        current.Preview!.Next = current.Next;
                        current.Next!.Preview = current.Preview;
                    }
                    _count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }





      
    }
    
    }}