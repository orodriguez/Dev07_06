namespace Tests;

public class HashMap<TKey, TValue> where TKey : notnull
{
    private readonly int _capacity;
    private readonly Bucket[] _buckets;

    public HashMap(int capacity = 10)
    {
        _capacity = capacity;
        _buckets = new Bucket[_capacity];
        for (var i = 0; i < _buckets.Length; i++)
            _buckets[i] = new Bucket();
    }

    public TValue this[TKey key] => Get(key);

    // Best(1) | Worst(n) | O(1)
    private TValue Get(TKey key)
    {
        var index = Hash(key);
        var bucket = _buckets[index];
        return bucket.Get(key);
    }
    
    // O(1)
    public void Add(TKey key, TValue value)
    {
        var index = Hash(key);
        _buckets[index].Add(key, value);
    }

    private int Hash(TKey key) => 
        Math.Abs(key.GetHashCode()) % _capacity;

    private class Bucket
    {
        private readonly LinkedList<(TKey Key, TValue Value)> _values;

        public Bucket() => 
            _values = new LinkedList<(TKey, TValue)>();

        public TValue Get(TKey key) =>
            // O(n)
            _values.First(pair => pair.Key.Equals(key)).Value;

        public void Add(TKey key, TValue value) =>
            // O(1)
            _values.AddLast((key, value));
    }
}