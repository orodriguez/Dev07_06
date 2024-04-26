namespace Implementations;

public class BSTreeNode
{
    public int Value { get; set; }
    public BSTreeNode? Left { get; set; }
    public BSTreeNode? Right { get; set; }

    public BSTreeNode(int value) //constructor
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


public int Max()
{
    if (this == null || this.Right == null)
    {
        return this.Value;
    }
    var current = this.Right;

    while (current.Right != null)
    {
        current = current.Right;
    }
    return current.Value;
}


public int Min()
{
    if (this == null || this.Left == null)
    {
        return this.Value;
    }
    var current = this.Left;

    while (current.Left != null)
    {
        current = current.Left;
    }
    return current.Value;
}



public int Height()
{
    if (this == null)
    {
        return 0;
    }
    else
    {
        int leftHeight = (this.Left != null) ? this.Left.Height() : 0;
        int rightHeight = (this.Right != null) ? this.Right.Height() : 0;
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}





}