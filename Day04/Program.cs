
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Day04;

public class Program
{
    static async Task<int> Main(string[] args)
    {
        try
        {
            var data = await File.ReadAllLinesAsync("input.txt");

            Debug.Assert(IsSquare(data));

            var word = "XMAS";
            var count = CountOccurences(data, word);
            Console.WriteLine($"There are {count} occurences of '{word}' in the input");

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return ex.HResult;
        }
    }

    static bool IsSquare(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if ( lines[i].Length != lines[i].Length )
                return false;
        } 

        return true;
    }

    public static IEnumerable<string> GetVerticalLines(string[] lines)
    {
        var columns = lines[0].Length;

        for (int column = 0; column < columns; column++)
        {
            char[] c = new char[columns];
            for(int i = 0; i< lines.Length; i++)
            {
                c[i] = lines[i][column];
            }

            yield return new string(c);

        }
    }

    public static IEnumerable<string> GetLtrDiagonalLines(string[] lines)
    {
        var size = lines.Length;

        for(int row = lines.Length-1; row > 0; row--)
        {
            char[] c = new char[size - row];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = lines[row+i][i];
            }

            yield return new string(c);
        }


        for (int column = 0; column < size; column++)
        {
            char[] c = new char[size-column];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = lines[i][column+i];
            }

            yield return new string(c);

        }
    }

    public static IEnumerable<string> GetRtlDiagonalLines(string[] lines)
    {
        var size = lines.Length;

        for (int column = 0; column < size; column++)
        {
            char[] c = new char[column +1];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = lines[i][column-i];
            }

            yield return new string(c);
        }


        for (int row = 1; row < size; row++)
        {
            char[] c = new char[size - row];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = lines[row+i][size-i-1];
            }

            yield return new string(c);

        }
    }

    private static int CountOccurences(string line, string word)
    {
        int count = 0;
        int startIndex = 0;
        int index;
        while ( (index = line.IndexOf(word, startIndex,StringComparison.Ordinal )) != -1) 
        {
            count++;
            startIndex = index + 1;
        }

        return count;
    }

    public static int CountOccurences(string[] lines, string word)
    {
        var wordRev = new string(word.Reverse().ToArray());
        int count = 0;

        // Horizontal
        foreach (string line in lines) 
        {
            count += CountOccurences(line, word);
            count += CountOccurences(line, wordRev);
        }

        // Vertical
        foreach (string line in GetVerticalLines(lines))
        {
            count += CountOccurences(line, word);
            count += CountOccurences(line, wordRev);
        }

        // Diagonal - left to right
        foreach (string line in GetLtrDiagonalLines(lines))
        {
            count += CountOccurences(line, word);
            count += CountOccurences(line, wordRev);
        }

        // Diagonal - left to right
        foreach (string line in GetRtlDiagonalLines(lines))
        {
            count += CountOccurences(line, word);
            count += CountOccurences(line, wordRev);
        }


        return count;
    }

    public static int Count_X_Occurences(string[] lines, string word)
    {
        throw new NotImplementedException();
    }

}
