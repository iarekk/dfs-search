using System;

namespace dfs_words
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[,]{
                {'Z','B','C','D'},
                {'A','B','C','D'},
                {'A','B','C','D'},
                {'A','B','C','D'},
            };

            var word = "AABBCD";

            Console.WriteLine(Searcher.Search(matrix, word));
        }
    }
}
