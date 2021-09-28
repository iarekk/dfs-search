using System.Collections.Generic;

public static class Searcher
{
    public static (bool, List<(int,int)>) Search(char[,] matrix, string word)
    {
        var size = matrix.Length;

        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                var (success, path) = CheckRecursive(matrix, word, (i,j), new List<(int,int)>());

                if(success)
                {
                    return (true, path);
                }
            }
        }

        return new (false, new List<(int,int)>());
    }

    public static (bool, List<(int,int)>) CheckRecursive(
        char [,] matrix,
        string wordRemaining, 
        (int, int) candidatePoint, 
        List<(int,int)> currentPath)
        {
            return (false, new List<(int,int)>());
        }
}