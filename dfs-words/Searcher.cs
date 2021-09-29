using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;

public static class Searcher
{
    public static (bool, IList<(int,int)>) Search(char[,] matrix, string word)
    {
        var size = matrix.Length;

        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                var (success, path) = CheckRecursive(matrix, new List<char>(word.ToCharArray()), (i,j), ImmutableList<(int,int)>.Empty);

                if(success)
                {
                    return (true, path);
                }
            }
        }

        return new (false, new List<(int,int)>());
    }

    public static (bool, IList<(int,int)>) CheckRecursive(
        char [,] matrix,
        List<char> wordRemaining, 
        (int, int) candidatePoint, 
        ImmutableList<(int,int)> currentPath)
    {
        var size = matrix.GetLength(0); // assume square

        var bad = (false, new List<(int,int)>());

        var (row, col) = candidatePoint;

        if (!IsValidCoord(size, candidatePoint, currentPath))
        {
            return bad;
        }

        if (matrix[row, col] == wordRemaining[0])
        {
            var newPath = currentPath.Add(candidatePoint);
            if (wordRemaining.Count == 1)
            {
                return (true, newPath);
            }

            var remWord = wordRemaining.Skip(1).ToList();

            {
                var (upResult, upPath) = CheckRecursive(matrix, remWord, (row-1, col), newPath);
                if(upResult){ return (true, upPath); }
            }

            {
                var (rightResult, rightPath) = CheckRecursive(matrix, remWord, (row, col+1), newPath);
                if(rightResult){ return (true, rightPath); }
            }

            {
                var (downResult, downPath) = CheckRecursive(matrix, remWord, (row+1, col), newPath);
                if(downResult){ return (true, downPath); }
            }

            {
                var (leftResult, leftPath) = CheckRecursive(matrix, remWord, (row, col-1), newPath);
                if(leftResult){ return (true, leftPath); }
            }            
        }

        

        return bad;
    }

    public static bool IsValidCoord(int size, (int, int) candidate, IList<(int,int)> currentPath)
    {
        var (x, y) = candidate;

        if(x < 0 || y < 0 || x >= size || y >= size || currentPath.Contains(candidate))
        {
            return false;
        }

        return true;
    }
}