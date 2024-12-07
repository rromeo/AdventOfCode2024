using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace Day03;

public class Program
{

    static int Main(string[] args)
    {
        try
        {
            var text = File.ReadAllText("input.txt");
            var sum = CorruptedSumOfMultiplies(text);

            if (sum == null)
                Console.WriteLine("No matches");
            else
                Console.WriteLine($"Sum of multiplies = {sum.Value}");

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
}
