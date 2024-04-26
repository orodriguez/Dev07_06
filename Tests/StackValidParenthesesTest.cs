using Implementations;
namespace Tests;
public class StackValidParenthesesTest
{
    [Fact]
    public void TestValid()
    {
        StackValidParentheses Validator = new StackValidParentheses();
        Assert.True(Validator.StackValidator("()"));
        Assert.True(Validator.StackValidator("()[]{}"));
        Assert.True(Validator.StackValidator("{[()]}"));
        Assert.True(Validator.StackValidator("{[()]}"));
        Assert.True(Validator.StackValidator(""));
    }
    [Fact]
    public void TestInvalid()
    {
        StackValidParentheses Validator = new StackValidParentheses();
        Assert.False(Validator.StackValidator("("));
        Assert.False(Validator.StackValidator(")"));
        Assert.False(Validator.StackValidator("([)]"));
        Assert.False(Validator.StackValidator("((()"));
    }
}