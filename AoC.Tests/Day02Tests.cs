using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Day02;
using System.Linq;

namespace AoC.Tests
{
    [TestClass]
    public sealed class Day02Tests
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
            var lines = testData.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
            var reports = Day02.Program.ParseIntDataByRow(lines);

            var isSafeList = reports.Select(report => Day02.Program.IsReportSafe(report)).ToList();
            List<bool> expected = [true, false, false, false, false, true];

            CollectionAssert.AreEqual(expected, isSafeList);
        }

        [TestMethod]
        public void Part2() 
        {
            var lines = testData.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
            var reports = Day02.Program.ParseIntDataByRow(lines);

            var isSafeList = reports.Select(report => Day02.Program.IsDampenedReportSafe(report)).ToList();
            List<bool> expected = [true, false, false, true, true, true];

            CollectionAssert.AreEqual(expected, isSafeList);
        }


    }
}
