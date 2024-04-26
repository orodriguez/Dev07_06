namespace Implementations;
public class StackValidParentheses
{
   public bool StackValidator(string s_validating)
   {
      // Puedo usar var por Stack, pero ! Nah xD
      Stack<char> StackDataStructure = new Stack<char>();
      foreach (char character in s_validating)
      {
         if (character == '(' || character == '[' || character =='{') 
         {
            StackDataStructure.Push(character);
         }
         else if (character == ')' || character == ']' || character == '}')
         {
            if (StackDataStructure.Count == 0)
               return false;
            char up = StackDataStructure.Pop();
            if ((character ==')' && up != '(' ) ||
            (character ==']' && up != '[' ) ||
               (character =='}' && up != '{' ))
            {
               return false;
            }
         }
      }
      return StackDataStructure.Count==0;
   }
}   