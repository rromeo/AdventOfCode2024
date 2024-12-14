
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day05;

public class Program
{
    static async Task Main(string[] args)
    {
        var data = await File.ReadAllLinesAsync("input.txt");

        Console.WriteLine("Hello, World!");
    }


    public static async Task<(List<List<int>> PageOrderRules, List<List<int>> PrintList)> ParseLinesAsync()
    {
        var data = await File.ReadAllLinesAsync("input.txt");
        
        var PageOrderRules = new List<List<int>>();
        var PrintList = new List<List<int>>();

        int i = 0;
        for(; i < data.Length; i++ )
        {
            if (string.IsNullOrEmpty(data[i])) 
                break;
            var order = data[i].Split('|');
            var orderList = order.Select(x => int.Parse(x)).ToList();
            PageOrderRules.Add(orderList);
        }

        i++;
        for (; i < data.Length; i++) 
        {
            if (string.IsNullOrEmpty(data[i]))
                break;

            // get the csv data
            var csv = data[i].Split(',');
            var csvList = csv.Select(x => int.Parse(x)).ToList();

            PrintList.Add(csvList);
        }

        return (PageOrderRules, PrintList);
    }

    public static int ComputeMiddleSum(string data)
    {
        throw new NotImplementedException();
    }
}
