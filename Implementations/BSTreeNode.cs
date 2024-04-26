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
    // Min
    public int Min()
    {
        if (Left == null)
            return Value;
        
        return Left.Min();
    }
    //Max
    public int Max()
    {
        if (Right == null)
            return Value;
        
        return Right.Max();
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
}