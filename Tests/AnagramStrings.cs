namespace Tests;

public class AnagramStrings
{
    [Theory]
    [InlineData("casa", "saca", true)]
    [InlineData("perro", "rreop", true)]
    [InlineData("hola", "aloh", true)]
    [InlineData("gato", "toga", true)]
    [InlineData("cielo", "nube", false)]
    [InlineData("feliz", "izlef", true)]
    public void TestIsAnagram(string s, string t, bool expectedResult)
    {
        var AnagramStringChecker = new AnagramStringChecker();
        bool result = AnagramStringChecker.SeraAnagram(s, t);
        if (expectedResult)
            Assert.True(result);
        else
            Assert.False(result);
    }
    
}