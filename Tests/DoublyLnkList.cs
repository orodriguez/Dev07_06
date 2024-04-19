namespace Tests;

public class DoublyLnkList<T> : ILnkList<T>
{
    public static DoublyLnkList<T> From(params T[] values)
    {
        throw new NotImplementedException();
    }

    public void Prepend(T value)
    {
        throw new NotImplementedException();
    }

    public void Append(T value)
    {
        throw new NotImplementedException();
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

    public int Count => throw new NotImplementedException();

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
}