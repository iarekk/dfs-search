using Xunit;
using System.Collections.Generic;
using FluentAssertions;

public class SearcherTests
{
    [Fact]
    public void SingleLetterPositiveTest()
    {
        var m = new char[,]{
            {'A', 'B'},
            {'C', 'D'},
        };
        var currentPath = new List<(int,int)> { (0,1)};
        var candidate = (0,0);
        var word = new List<char>(){'A'};
        var (s, p) = Searcher.CheckRecursive(m, word, candidate, currentPath);

        Assert.True(Searcher.IsValidCoord(m.Length, candidate, currentPath));
        Assert.True(s);
        p.Should().BeEquivalentTo(new List<(int,int)>{(0,1),(0,0)});
    }

        [Fact]
    public void SingleLetterWrongLetterTest()
    {
        var m = new char[,]{
            {'A', 'B'},
            {'C', 'D'},
        };
        var currentPath = new List<(int,int)> { (0,1)};
        var candidate = (0,0);
        var word = new List<char>(){'B'};
        var (s, p) = Searcher.CheckRecursive(m, word, candidate, currentPath);

        Assert.True(Searcher.IsValidCoord(m.Length, candidate, currentPath));
        Assert.False(s);
        p.Should().BeEquivalentTo(new List<(int,int)>());
    }

            [Fact]
    public void ComplexTest()
    {
        char[,] m = new char[,]{
            {'Z','B','C','D'},
            {'Z','B','C','D'},
            {'A','B','C','D'},
            {'A','B','C','D'},
        };

        var word = new List<char>("AABBCD");
        var (s, p) = Searcher.CheckRecursive(m, word, (3,0), new List<(int,int)>());

        Assert.True(s);
        p.Should().BeEquivalentTo(new List<(int,int)>() { (3,0), (2,0), (2,1), (1,1), (1,2), (1,3)  });
    }

    [Fact]
    public void ComplexTest2()
    {
        char[,] m = new char[,]{
            {'S','N','U'},
            {'N','A','F'},
            {'S','K','E'}
        };

        var (s, p) = Searcher.Search(m, "SNAKEFUNS");

        Assert.True(s);
        p.Should().BeEquivalentTo(new List<(int,int)>() { 
            (2,0), 
            (1,0), 
            (1,1), 
            (2,1), 
            (2,2), 
            (1,2),
            (0,2),
            (0,1),
            (0,0)});
    }
}