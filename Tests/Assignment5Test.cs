using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementations;

namespace Tests
{
    public class Assignment5Test
    {
        Assignment5 proof = new Assignment5();
        [Fact]
        public void Parenthesis()
        {
            string s = "()";
            Assert.True(proof.IsValid(s));
        }
        [Fact]
        public void AllParenthesis()
        {
            string s = "()[]{}";
            Assert.True(proof.IsValid(s));
        }
        [Fact]
        public void WrongParenthesis()
        {
            string s = "(]";
            Assert.False(proof.IsValid(s));
        }
        [Fact]
        public void EmptyString()
        {
            string s = "";
            Assert.False(proof.IsValid(s));
        }
        [Fact]
        public void NestedParenthesis()
        {
            string s = "({[]})";
            Assert.True(proof.IsValid(s));
        }
        [Fact]
        public void Words()
        {
            string s = "(as)";
            Assert.False(proof.IsValid(s));
        }
        [Fact]
        public void IncompleteParenthesis()
        {
            string s = "{}[](";
            Assert.False(proof.IsValid(s));
        }
        [Fact]
        public void ClosingParenthesisFirst()
        {
            string s = "}{[]()";
            Assert.False(proof.IsValid(s));
        }
    }
}
