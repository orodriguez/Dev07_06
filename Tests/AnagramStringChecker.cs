namespace Tests;

public class AnagramStringChecker
{
    public bool SeraAnagram(string s, string t)
    {
        // Verificar si las longitudes son diferentes
        if (s.Length != t.Length)
            return false;

        // Convertir las cadenas en arreglos de caracteres
        char[] sChars = s.ToCharArray();
        char[] tChars = t.ToCharArray();

        // Ordenar los arreglos de caracteres
        Array.Sort(sChars);
        Array.Sort(tChars);

        // Comparar los arreglos de caracteres ordenados
        for (int i = 0; i < sChars.Length; i++)
        {
            if (sChars[i] != tChars[i])
                return false;
        }

        return true;
    }

}