namespace Tests;

public class DoublyLnkList<T> : ILnkList<T>
{
    private class Node
    {
        public T Data;
        public Node Next;
        public Node Previous;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;


    public void Append(T value)
    {
        Node newNode = new Node(value);

        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }

        count++;
    }

    public T this[int index]
    {
        get => Get(index);
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException($"Index {index} is out of range.");

        if (index == 0)
            return head.Data;

        if (index == count - 1)
            return tail.Data;

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    public static DoublyLnkList<T> From(params T[] values)
    {
        DoublyLnkList<T> newList = new DoublyLnkList<T>();

        foreach (T value in values)
        {
            newList.Append(value);
        }

        return newList;
    }

    public void Prepend(T value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {

            head = newNode;
            tail = newNode;
        }
        else
        {

            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }

        count++;
    }

    public T First()
    {
        if (head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        return head.Data;
    }

    public bool Any(Func<T, bool> compare)
    {
        Node current = head;
        while (current != null)
        {
            if (compare(current.Data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int Count()
    {
        return count;
    }

    public IEnumerable<T> ToEnumerable()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    public IEnumerable<T> ToReversedEnumerable()
    {
        var current = tail; // Start from the tail of the list

        while (current != null)
        {
            yield return current.Data; // Yield the data of the current node
            current = current.Previous; // Move to the previous node
        }
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            return false; // Index out of range

        if (index == 0)
        {
            // Remove the first element
            head = head.Next;
            if (head != null)
                head.Previous = null;
            else
                tail = null; // Update tail if head is null
        }
        else if (index == count - 1)
        {
            // Remove the last element
            tail = tail.Previous;
            tail.Next = null;
        }
        else
        {
            // Remove an element in the middle
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
        }

        count--;
        return true; // Element removed successfully
    }

    public bool Remove(T value)
    {
        Node current = head;

        while (current != null)
        {
            if (current.Data.Equals(value))
            {
                if (current == head)
                {
                    head = head.Next;
                    if (head != null)
                        head.Previous = null;
                    else
                        tail = null;
                }
                else if (current == tail)
                {
                    tail = tail.Previous;
                    if (tail != null)
                        tail.Next = null;
                    else
                        head = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }

                count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    }


