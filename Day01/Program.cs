
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day01;

class Program
{
    static async Task<int> Main(string[] args) 
    {

        const string fileName = "input.txt";


        try
        {
            var (list1, list2) = await ReadFileAsync(fileName);

            list1.Sort();
            list2.Sort();

            Debug.Assert(list1.Count == list2.Count);

            var distance = list1.Zip(list2).Select(x => (long)Math.Abs(x.First - x.Second)).Sum();

            Console.WriteLine($"Distance = {distance}");

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
            return 1;
        }

        return 0;

    }

    private static async Task<(List<int>, List<int>)> ReadFileAsync(string filename)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        var lineArray = await File.ReadAllLinesAsync(filename);
        foreach (var line in lineArray)
        {
            var column = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (column.Length == 0)
                continue;
            if (column.Length == 2)
            {
                var int1 = int.Parse(column[0]);
                var int2 = int.Parse(column[1]);

                list1.Add(int1);
                list2.Add(int2);
            }
            else
            {

                throw new FormatException("Improper number of columns in file");

            }
        }

        return (list1, list2);
    }

}





