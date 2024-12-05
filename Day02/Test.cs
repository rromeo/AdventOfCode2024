using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.VisualStudio.TestTools.UnitTesting;

using Day02;

namespace Day02;

[TestClass]
public class Test
{
    static string testData = 
@"
7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9
";

    [TestMethod]
    public void Part1()
    {
        var lines = testData.Split(['\r','\n'], StringSplitOptions.RemoveEmptyEntries);
        var reports = Program.ParseIntDataByRow(lines);

        var isSafeList = reports.Select(report => Program.IsSafe(report)).ToList();
        List<bool> expected = [true, false, false, false, false, true];

        CollectionAssert.AreEqual(expected, isSafeList);
    }

}
