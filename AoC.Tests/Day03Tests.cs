using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Day03;

namespace AoC.Tests;

[TestClass]
public class Day03Tests
{

    [TestMethod]
    [DataRow("mul(44,46)", 2024)]
    [DataRow("mul(123,4)", 123*4)]
    [DataRow("mul(4*", null)]
    [DataRow("mul(6,9!", null)]
    [DataRow("?(12,34)", null)]
    [DataRow("mul( 2 , 4 )", null)]
    [DataRow("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161)]
    public void TestMethod1(string data, int? result)
    {
        Assert.IsTrue(Day03.Program.CorruptedSumOfMultiplies(data) == result);
        
    }

    [TestMethod]
    [DataRow("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",48)]
    public void Part2Test(string data, int? result)
    {
        Assert.IsTrue(Day03.Program.CorruptedSumOfMultiplies2(data) == result);
    }
}
