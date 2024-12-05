
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

            var count = lineArray.Select(x => IsReportSafe(ParseIntRow(x))).Count(x => x);

            Console.WriteLine(count);

            return 0;
        }
        catch (Exception ex) 
        { 
            Console.Error.WriteLine(ex);
            return 1;
        }

    }

    public static bool IsReportSafe(List<int> report)
    {
        bool? isIncreasing = null;

        var diff = report.Zip(report.Skip(1)).Select(x => x.Second - x.First);
        foreach (var x in diff) 
        {
            var absDiff = Math.Abs(x);
            if ( !(absDiff >= 1 && absDiff <= 3) )
                return false;

            if ( isIncreasing.HasValue )
            {
                if ( isIncreasing == true && (x < 0) || isIncreasing == false && (x > 0))
                    return false;

            } 
            else
            {
                // here: 1 <= |x| <= 3 
                isIncreasing = (x > 0);
            }

        }

        return true;
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
