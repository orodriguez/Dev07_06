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

    public TValue this[TKey key]
    {
        get => Get(key);
        set => Add(key, value);
    }

    public IEnumerable<TKey> Keys() => 
        _buckets.SelectMany(bucket => bucket.Keys());

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

    public bool Contains(TKey key)
    {
        var bucket = _buckets[Hash(key)];
        return bucket.Contains(key);
    }

    public bool Remove(TKey key)
    {
        var bucket = _buckets[Hash(key)];
        return bucket.Remove(key);
    }

    private class Bucket
    {
        private readonly LinkedList<(TKey Key, TValue Value)> _values;

        public Bucket() => 
            _values = new LinkedList<(TKey, TValue)>();

        public TValue Get(TKey key) =>
            // O(n)
            _values.First(pair => pair.Key.Equals(key)).Value;

        public void Add(TKey key, TValue value)
        {
            // Best(1)
            // O(n)
            // O(n / capacity)
            if (Contains(key))
                Remove(key);
            
            // O(1)
            _values.AddLast((key, value));
        }

        public bool Contains(TKey key) => 
            _values.Any(pair => pair.Key.Equals(key));

        public bool Remove(TKey key)
        {
            var value = Get(key);
            return _values.Remove((key, value));
        }

        public IEnumerable<TKey> Keys() => 
            _values.Select(pair => pair.Key);
    }
}