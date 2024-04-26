namespace Tests;

public class StackTests
{
    [Fact]
    public void Pop()
    {
        // LIFO
        var s = new Stack<string>();
        
        s.Push("A");
        s.Push("B");

        var actual = s.Pop();
        
        Assert.Equal("B", actual);
        Assert.Equal("A", s.Peek());
    }

    [Fact]
    public void Pop_Empty()
    {
        var s = new Stack<int>();
        
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }

    [Fact]
    public void AsEnumerable()
    {
        var s = new Stack<int>();
        
        s.Push(1);
        s.Push(2);
        s.Push(3);
        
        Assert.Equal(new[] { 3, 2, 1}, s);
    }
    
    
    [Fact]
    public void IsValid_Parenthesis_Single_True()
    {
        Assert.True(IsValid("()"));
    }
    
    [Fact]
    public void IsValid_Parenthesis_Single_False()
    {
        Assert.False(IsValid("("));
    }
    
    [Fact]
    public void IsValid_Parenthesis_True()
    {
        Assert.True(IsValid("(){}[]"));
    }
    
    [Fact]
    public void IsValid_Parenthesis_Multiple()
    {
        Assert.True(IsValid("(){[]}"));
    }
    
    [Fact]
    public void IsValid_Parenthesis_One_Inside_Another()
    {
        Assert.True(IsValid("(){[]()}"));
    }
    
    [Fact]
    public void IsValid_Parenthesis_False()
    {
        Assert.False(IsValid("(){[]("));
    }

    
    public bool IsValid(string s)
    {
        if (s.Length == 1)
            return false;
        
        var stack = new Stack<char>();
        foreach (var letter in s)
        {
            if (letter is '(' or '{' or '['){
                stack.Push(letter);
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                var open = stack.Pop();
                if ((letter == ')' && open != '(') ||
                    (letter == ']' && open != '[') ||
                    (letter == '}' && open != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
    
    
}