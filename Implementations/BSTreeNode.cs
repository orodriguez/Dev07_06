namespace Implementations;

public class BSTreeNode
{
    public int Value { get; set; }
    public BSTreeNode? Left { get; set; }
    public BSTreeNode? Right { get; set; }

    public BSTreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    public void Add(int value)
    {
        if (Value == value)
            return;

        if (Value > value)
        {
            if (Left == null)
            {
                Left = new BSTreeNode(value);
                return;
            }
            
            Left.Add(value);
            return;
        }

        if (Right == null)
        {
            Right = new BSTreeNode(value);
            return;
        }
        
        Right.Add(value);
    }

    public int LeftValue => Left!.Value;
    public int RightValue => Right!.Value;

    public bool Contains(int value)
    {
        if (Value == value)
            return true;

        if (Value > value)
            return Left != null && Left.Contains(value);

        return Right != null && Right.Contains(value);
    }
    public int Min()
    {
        return this.Left == null ? this.Value : this.Left.Min();
    }
    public int Max()
    {
        return this.Right == null? this.Value : this.Right.Max();
    }
}