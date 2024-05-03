namespace Implementations;

public class Graph<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _edges;

    public Graph() => _edges = new Dictionary<T, List<T>>();

    public IEnumerable<IEnumerable<T>> Paths(T start, T end) => 
        Paths(Array.Empty<T>(), start, end);

    // O(e)
    private IEnumerable<IEnumerable<T>> Paths(IEnumerable<T> prefix, T start, T end)
    {
        if (!_edges.ContainsKey(start))
            return Array.Empty<T[]>();

        if (start.Equals(end))
            return new[] { prefix.Concat(new[] { start }) };
        
        return _edges[start]
            .Where(node => !node.Equals(start))
            .Where(node => !prefix.Contains(node))
            .Select(node => Paths(prefix.Concat(new[] { start }), node, end))
            .SelectMany(paths => paths);
    }

    public void Add(T from, T to)
    {
        if (!_edges.ContainsKey(from))
            _edges[from] = new List<T>();

        if (!_edges.ContainsKey(to))
            _edges[to] = new List<T>();
        
        _edges[from].Add(to);
    }

    public IEnumerable<T> ShortestPath(T start, T end)
    {
        var visited = new HashSet<T>();
        var queue = new Queue<Tuple<T, List<T>>>();

        visited.Add(start);
        queue.Enqueue(new Tuple<T, List<T>>(start, new List<T> { start }));

        while (queue.Count > 0)
        {
            var (current, path) = queue.Dequeue();
            if (current.Equals(end))
                return path;

            foreach (var neighbor in _edges[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    var newPath = new List<T>(path);
                    newPath.Add(neighbor);
                    queue.Enqueue(new Tuple<T, List<T>>(neighbor, newPath));
                }
            }
        }
        return Enumerable.Empty<T>();
    }
}