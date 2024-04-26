using Implementations;

namespace Tests;
public class ValidParenthesisTests
{

    [Fact]
    public void Is_Valid(){
        Assert.True(IsValid("()"));
        Assert.True(IsValid2("()"));
    }

    [Fact]
    public void Is_Valid2(){
        Assert.True(IsValid("()[]{}{}{}{}()"));
        Assert.True(IsValid2("()[]{}{}{}{}()"));
    }

    [Fact]
    public void Is_empty(){
        Assert.False(IsValid(""));
        Assert.False(IsValid2(""));
    }

    [Fact]
    public void IsNot_Valid(){
        Assert.False(IsValid("(]"));
        Assert.False(IsValid2("(]"));
    }

    [Fact]
    public void IsNot_Valid2(){
        Assert.False(IsValid("(]"));
        Assert.False(IsValid2("(]"));
    }


    public bool IsValid(string s){
        if(s == String.Empty) return false;

        Stack<char> stack = new Stack<char>();
        
        foreach(char c in s){
            if(c == '(' || c == '{' || c == '['){
                stack.Push(c);
            }
            else if(stack.Count == 0 || 
            (c == ')' && stack.Pop() != '(') ||
            (c == '}' && stack.Pop() != '{') ||
            (c == ']' && stack.Pop() != '[')){
                return false;
            }
        }
        return stack.Count == 0;
    }

    public bool IsValid2(string s){
        if(s == String.Empty) return false;
        for(int i = 0; i < s.Length; i+=2){
            if((s[i] == '(' && s[i+1] != ')') || (s[i] == '[' && s[i+1] != ']') || (s[i] == '{' && s[i+1] != '}')) return false;
        }
        return true;
    }

}

