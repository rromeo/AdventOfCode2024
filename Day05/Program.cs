
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day05;

public class Program
{
    static async Task<int> Main(string[] args)
    {
        try
        {
            string data = await File.ReadAllTextAsync("input.txt");
            int result = ComputeMiddleSum(data);

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }

    }


    public static (List<List<int>> PageOrderRules, List<List<int>> PrintList) ParseLines(string data)
    {
       
        var PageOrderRules = new List<List<int>>();
        var PrintList = new List<List<int>>();

        using(StringReader reader = new StringReader(data))
        {
            string? line;
            while( (line = reader.ReadLine()) != null) 
            {
                if (string.IsNullOrEmpty(line)) 
                    break;
                var order = line.Split('|');
                var orderList = order.Select(x => int.Parse(x)).ToList();
                PageOrderRules.Add(orderList);
            }

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    break;
                // get the csv data
                var csv = line.Split(',');
                var csvList = csv.Select(x => int.Parse(x)).ToList();

                PrintList.Add(csvList);
            }

        }


        return (PageOrderRules, PrintList);
    }

    public static int ComputeMiddleSum(string data)
    {
        var (rules, printList) = ParseLines(data);

        return 0;

    }

}
