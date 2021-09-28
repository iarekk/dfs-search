using System;
using Newtonsoft.Json;

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

            var word = "AABBCDDD";

            Console.WriteLine(JsonConvert.SerializeObject(Searcher.Search(matrix, word), Formatting.Indented));
        }
    }
}
