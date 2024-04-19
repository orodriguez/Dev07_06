namespace Tests;

public interface ILnkList<T>
{
    void Prepend(T value);
    void Append(T value);
    T First();
    bool Any(Func<T, bool> compare);
    T this[int index] { get; }
    T Get(int index);
    //int Count;
    IEnumerable<T> ToEnumerable();
    bool RemoveAt(int index);
    bool Remove(T value);
}