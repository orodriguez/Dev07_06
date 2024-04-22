using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tests
{
    public class DoublyLnkList<T> : ILnkList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        private class Node<U>
        {
            public U Value { get; set; }
            public Node<U> Previous { get; set; }
            public Node<U> Next { get; set; }

            public Node(U value)
            {
                Value = value;
            }
        }

        public DoublyLnkList()
        {
            head = null;
            tail = null;
            count = 0;
        }

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
            var newNode = new Node<T>(value);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            count++;
        }

        public void Append(T value)
        {
            var newNode = new Node<T>(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            count++;
        }

        public T First()
        {
            if (head == null) throw new InvalidOperationException("La lista está vacía.");
            return head.Value;
        }

        public bool Any(Func<T, bool> compare)
        {
            var current = head;
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

        public T this[int index] => Get(index);

        public T Get(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public int Count()
        {
            return count;
        }

        public IEnumerable<T> ToEnumerable()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerable<T> ToReversedEnumerable()
        {
            var current = tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                return false;
            }
            Node<T> current = head;
            if (index == 0)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null;
                }
                else
                {
                    tail = null;
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Previous.Next = current.Next;
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }
            }
            count--;
            return true;
        }

        public bool Remove(T value)
        {
            Node<T> current = head;
            while (current != null && !current.Value.Equals(value))
            {
                current = current.Next;
            }

            if (current == null)
            {
                return false;
            }

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                tail = current.Previous;
            }

            count--;
            return true;
        }
    }
}
