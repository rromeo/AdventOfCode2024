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
    public void TestMethod1(string data, int result)
    {
        Assert.IsTrue(Day03.Program.CorruptedSumOfMultiplies(data) == result);
        
    }
}
