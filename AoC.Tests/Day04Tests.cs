using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day04;
using System.IO;


namespace AoC.Tests
{
    [TestClass]
    public class Day04Tests
    {
        static readonly string[] diagTest = ["abc", "def", "ghi"];

        const string sampleData1 =
@"
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
";

        const string sampleData2 =
@"
....XXMAS.
.SAMXMS...
...S..A...
..A.A.MS.X
XMASAMX.MM
X.....XA.A
S.S.S.S.SS
.A.A.A.A.A
..M.M.M.MM
.X.X.XMASX
";

        const string part2Data =
@"
.M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
..........
";

        string[] ParseData(string data)
        {
            var lines = new List<string>();
            using (var reader = new StringReader(data))
            {
                string? line;
                while ( (line = reader.ReadLine()) != null) 
                { 
                    if (string.IsNullOrEmpty(line)) 
                        continue;
                    lines.Add(line);
                }

            }

            return lines.ToArray();
        }

        [TestMethod] 
        public void TestVerticalLines() 
        {
            string[] expecting = ["adg", "beh", "cfi"];
            var diagonals = Day04.Program.GetVerticalLines(diagTest).ToArray();

            CollectionAssert.AreEqual(expecting, diagonals);
        }

        [TestMethod]
        public void TestLtrDiagonal() 
        {
            string[] expecting = ["g", "dh", "aei", "bf", "c"];
            var diagonals = Day04.Program.GetLtrDiagonalLines(diagTest).ToArray();

            CollectionAssert.AreEqual(expecting, diagonals);
        }

        [TestMethod]
        public void TestRtlDiagonal()
        {
            string[] expecting = ["a","bd","ceg", "fh", "i"];
            var diagonals = Day04.Program.GetRtlDiagonalLines(diagTest).ToArray();

            CollectionAssert.AreEqual(expecting, diagonals);
        }




        [TestMethod]
        public void Part1()
        {
            Assert.IsTrue(Day04.Program.CountOccurences(ParseData(sampleData1), "XMAS") == 18);
            Assert.IsTrue(Day04.Program.CountOccurences(ParseData(sampleData2), "XMAS") == 18);
        }

        [TestMethod]
        public void Part2()
        {
            Assert.IsTrue(Day04.Program.CountOccurences(ParseData(part2Data), "MAS") == 9);
        }


    }
}
