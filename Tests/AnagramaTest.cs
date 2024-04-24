using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AnagramaTest
    {
        [Fact]
        public void Is_Anagram()
        {
            string s = "ana";
            string t = "aan";

            Assert.True(IsAnagram(s, t));
        }
        [Fact]
        public void IsNot_Anagram()
        {
            string s = "car";
            string t = "rat";

            Assert.False(IsAnagram(s, t));
        }

        [Fact]
        public void IsUpper_Anagram()
        {
            string s = "Anagram";
            string t = "grAnmAA";

            Assert.True(IsAnagram(s, t));
        }


        private bool IsAnagram(string s, string t)
        {

            char[] sArray = s.ToLower().ToCharArray();
            char[] tArray = t.ToLower().ToCharArray();
            
            Array.Sort(sArray);
            Array.Sort(tArray);

            return new string(sArray) == new string(tArray);
        }
    }
}
