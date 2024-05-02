using AAD;

namespace Implementations;
// Name 'BSTree' does not match rule 'Types and namespaces'. Suggested name is 'BsTree'
// public class BSTree
public class BsTree
{
    private BSTreeNode? _root;

    public BsTree() : this(null)
    {
    }

    private BsTree(BSTreeNode? root) =>
        _root = root;

    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new BSTreeNode(value);
            return;
        }
        
        _root.Add(value);
    }

    public int Count()
    {
        if (_root == null)
            return 0;

        return _root.Count();
    }

    public bool Contains(int value)
    {
        if (_root == null)
            return false;
        
        return _root.Contains(value);
    }

    public void Delete(int valueToDelete)
    {
        if (_root == null)
            return;

        _root = _root.Delete(valueToDelete);
    }
}