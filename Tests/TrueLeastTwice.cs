namespace Tests; // By-Daves !davesdevs
public class TrueLeastTwice
{
    // Si tenemos repetidos = true
    [Fact]
    public void LeastTwiceTrue()
    {
        var trueLeastTwice = new TrueLeastTwice();
        Assert.True(trueLeastTwice.Checker(new int[] { 6, 7, 8, 9, 10, 6, 7, 8, 9, 10 }));
    }
    // Si ninguno esta repetido = false
    [Fact]
    public void DiffFalse()
    {
        var difffalse = new TrueLeastTwice();
        Assert.True(difffalse.Checker(new int[] { 9, -3, 5, -7, 2, 10, -5, 1, 3, 9 }));
    }
    private bool Checker(int[] damedatos) //BigO(1) ! 
    {
        /*
         * Why ? HashSet !, cuz !, it can store
         *  -Firts: is an BigO(1) FOR check if elemento existe,Internamente usa hashing techniques to organize and store elements
         *          Lo cual lo hace fast para hacer lookups !
         *  -Seccond: Elimination of Duplicates is fast
         *            Third: Efficient Memory Usage, escala bien, con grandes dataSets, sin consumir memoria de-MAS xD
         */
        HashSet<int> vamos_a_revisar = new HashSet<int>();
        foreach (int toma_palde_de_enteros in damedatos)
        {
            if (vamos_a_revisar.Contains(toma_palde_de_enteros))
            {
                // If yes, return true as we found a duplicate
                return true;
            }
            vamos_a_revisar.Add(toma_palde_de_enteros);
        }
        // If NO, return false as we NOT -> found ANY duplicate
        return false;
        //Bye !
    }
}