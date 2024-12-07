
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day02;

public class Program
{
    const string fileName = "input.txt";
    static async Task<int> Main(string[] args)
    {
        try
        {
            var lineArray = await File.ReadAllLinesAsync(fileName);

            var part1count = lineArray.Select(x => IsReportSafe(ParseIntRow(x))).Count(x => x);
            Console.WriteLine($"Part1 count: {part1count}");

            var part2count = lineArray.Select(x => IsDampenedReportSafe(ParseIntRow(x))).Count(x => x);
            Console.WriteLine($"Part2 dampened count: {part2count}");

            return 0;
        }
        catch (Exception ex) 
        { 
            Console.Error.WriteLine(ex);
            return 1;
        }

    }

    [Flags]
    enum Direction
    {
        None = 0,
        Increasing = 1,
        Decreasing = 2,
        Both = Increasing | Decreasing
    }

    public static bool IsReportSafe(List<int> report)
    {
        var diff = report.Zip(report.Skip(1)).Select(x => x.Second - x.First);
        Direction direction = Direction.None;
        foreach (var x in diff) 
        {
            var absDiff = Math.Abs(x);
            if ( !(absDiff >= 1 && absDiff <= 3) )
                return false;

            // here: 1 <= |x| <= 3, we can only be increasing or decreasing

            direction |= (x > 0) ? Direction.Increasing : Direction.Decreasing;
            if (direction == Direction.Both)
                return false;

        }

        return true;
    }

    private static bool IsDampenedReportSafe_BruteForce(List<int> report)
    {
        if (IsReportSafe(report))
            return true;

        for (int i = 0; i < report.Count; i++)
        {
            var array = new List<int>(report);
            array.RemoveAt(i);
            if (IsReportSafe(array))
                return true;
        }
        return false;
    }
    public static bool IsDampenedReportSafe(List<int> report)
    {
        return IsDampenedReportSafe_BruteForce(report);
    }

    private static List<int> ParseIntRow(string line)
    {
        string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 0)
            return [];

        var row = new List<int>();
        for (int i = 0; i < split.Length; i++)
        {
            row.Add(int.Parse(split[i]));
        }

        return row;
    }


    public static List<List<int>> ParseIntDataByRow(string[] lines)
    {
        var rows = new List<List<int>>();

        foreach(var line in lines)
        { 
            string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if ( split.Length == 0)
                continue;

            var row = new List<int>();
            for (int i = 0; i < split.Length; i++)
            {
                row.Add(int.Parse(split[i]));
            }

            rows.Add(row);
        }

        return rows;
    }

    public static IEnumerable<List<int>> ParseIntDataByColumn(string[] lines)
    {
        foreach (var line in lines)
        {
            string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 0)
                continue;

            List<int> values = [];
            for (int i = 0; i < split.Length; i++)
            {
                values.Add(int.Parse(split[i]));
            }

            yield return values;

        }

    }
}
