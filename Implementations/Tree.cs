namespace Implementations;

public class Tree<T>
{
    private TreeNode? _root;

    public Tree() =>
        _root = null;

    public Tree(T rootValue) =>
        _root = new TreeNode(rootValue);

    public int Count() => _root?.Count() ?? 0;

    public Tree<T> Add(T value) =>
        Add(new TreeNode(value));

    private Tree<T> Add(TreeNode node)
    {
        if (_root == null)
        {
            _root = node;
            return this;
        }

        _root.Add(node);
        return this;
    }

    public Tree<T> Add(T value, Action<TreeNode> action)
    {
        var node = new TreeNode(value);
        Add(node);
        action(node);
        return this;
    }

    public void TraversePreOrder(Action<T> action) => 
        _root?.TraversePreOrder(action);

    public void TraversePostOrder(Action<T> action) => 
        _root?.TraversePostOrder(action);

    public class TreeNode
    {
        public T Value { get; set; }
        private IList<TreeNode> Children { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public int Count() =>
            Children.Sum(node => node.Count()) + 1;

        public TreeNode Add(T value) =>
            Add(new TreeNode(value));

        public TreeNode Add(TreeNode node)
        {
            Children.Add(node);
            return this;
        }

        public TreeNode Add(T value, Action<TreeNode> action)
        {
            var node = new TreeNode(value);
            Add(node);
            action(node);
            return this;
        }

        public void TraversePreOrder(Action<T> action)
        {
            action(Value);

            foreach (var child in Children) 
                child.TraversePreOrder(action);
        }

        public void TraversePostOrder(Action<T> action)
        {
            foreach (var child in Children) 
                child.TraversePostOrder(action);
            
            action(Value);
        }
    }
}