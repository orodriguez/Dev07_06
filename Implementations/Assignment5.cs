using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class Assignment5
    {
        public bool IsValid(string s)
        {
            if(s == string.Empty)
            {
                return false;
            }
            Stack<char> stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if(!stack.Any())
                    {
                        return false;
                    }
                    var popped = stack.Pop();
                    if(c == ')' && popped != '(' ||
                        c == '}' && popped != '{' ||
                        c == ']' && popped != '[')
                    {
                        return false;
                    }
                }
                else 
                {
                    //In the original ex, the string can only contain "(){}[]", anything else will be catched as a mistake
                    return false;
                }
            }
            return !stack.Any();
        }
    }
}
