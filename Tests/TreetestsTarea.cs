namespace Tests;

class Program 
{
    static void Main() 
    {
        TreetestsTarea solution = new TreetestsTarea();

        string s1 = "()";
        Console.WriteLine(solution.IsValid(s1)); // Output: True

        string s2 = "()[]{}";
        Console.WriteLine(solution.IsValid(s2)); // Output: True

        string s3 = "(]";
        Console.WriteLine(solution.IsValid(s3)); // Output: False
    }
}

public class TreetestsTarea
{
    public bool IsValid(string s) 
    {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                    return false;
                
                char top = stack.Pop();
                
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    return false;
            }
        }
        
        return stack.Count == 0;
    }
}
