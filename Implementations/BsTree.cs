using AAD;

namespace Implementations;

public class BsTree
{
    private BsTreeNode? _root;

    public  BsTree() : this(null)
    {
    }

    private  BsTree(BsTreeNode? root) =>
        _root = root;

    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new BsTreeNode(value);
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
    
    public void Copy(BsTree emptyTree)
    {
        if (emptyTree == null)
        {
            throw new ArgumentNullException(nameof(emptyTree), "The empty tree must not be null.");
        }

        // Clear the contents of the empty tree
        emptyTree.Clear();

        // Copy the contents of the current tree to the empty tree
        if (_root != null)
        {
            emptyTree._root = CopySubtree(_root);
        }
    }

    private BsTreeNode CopySubtree(BsTreeNode originalNode)
    {
        var newNode = new BsTreeNode(originalNode.Value);
        if (originalNode.Left != null)
        {
            newNode.Left = CopySubtree(originalNode.Left);
        }

        if (originalNode.Right != null)
        {
            newNode.Right = CopySubtree(originalNode.Right);
        }

        return newNode;
    }

    public void Clear()
    {
        _root = null;
    }
    
    
    
}