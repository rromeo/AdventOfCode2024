
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

            // Part1: Compute distance - now that we have the lists sorted, just compute the difference

            Debug.Assert(list1.Count == list2.Count);

            var distance = list1.Zip(list2).Select(x => (long)Math.Abs(x.First - x.Second)).Sum();

            Console.WriteLine($"Distance = {distance}");

            // Part2: Compute Similarity - For each list get the count of each element

            var list1ElementCount = list1.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).ToList();
            var list2ElementCount = list2.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).ToList();

            var similarity = list1ElementCount.Join(list2ElementCount, l1 => l1.Key, l2 => l2.Key, (l1, l2) => (long)l1.Key * l1.Count * l2.Count).Sum();

            Console.WriteLine($"Similarity = {similarity}");
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





