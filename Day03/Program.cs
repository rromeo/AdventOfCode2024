
using System.Text.RegularExpressions;

namespace Day03;

public class Program
{

    static int Main(string[] args)
    {
        try
        {
            var text = File.ReadAllText("input.txt");
            var sum1 = CorruptedSumOfMultiplies(text);

            if (sum1 == null)
                Console.WriteLine("Part1 - No matches");
            else
                Console.WriteLine($"Part1 - Sum of multiplies = {sum1.Value}");

            var sum2 = CorruptedSumOfMultiplies2(text);
            if (sum2 == null)
                Console.WriteLine("Part2 - No matches");
            else
                Console.WriteLine($"Part2 - Sum of multiplies = {sum2.Value}");

            return 0;
        }
        catch (Exception ex) 
        { 
            Console.Error.WriteLine(ex.Message);
            return ex.HResult;
        }
    }

    public static int? CorruptedSumOfMultiplies(string data)
    {
        Regex pattern = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

        int sum = 0;
        bool hasValue = false;
        var matches = pattern.Matches(data);
        foreach (Match match in matches) 
        {
            var groups = match.Groups;
            var p1 = int.Parse(groups[1].ValueSpan);
            var p2 = int.Parse(groups[2].ValueSpan);

            hasValue = true;
            sum += p1 * p2;

        }

        return hasValue ? sum : null;

    }

    public static int? CorruptedSumOfMultiplies2(string data) 
    {
        throw new NotImplementedException();
    }
}
