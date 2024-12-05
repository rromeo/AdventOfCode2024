
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day02;

internal class Program
{
    const string fileName = "input.txt";
    static async Task Main(string[] args)
    {

        var lineArray = await File.ReadAllLinesAsync(fileName);

        try
        {
            foreach (var line in ParseIntDataByRow(lineArray))
            {

            };

        }
        catch (Exception ex) 
        { 
        
        }

    }

    public static bool IsSafe(List<int> report)
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
