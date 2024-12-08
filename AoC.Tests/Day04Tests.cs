using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day04;


namespace AoC.Tests
{
    [TestClass]
    public class Day04Tests
    {
        static string sampleData1 =
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

        string sampleData2 =
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

        [TestMethod]
        public void Part1()
        {
            Assert.IsTrue(Day04.Program.CountOccurances(sampleData1, "XMAS") == 18);
            Assert.IsTrue(Day04.Program.CountOccurances(sampleData2, "XMAS") == 18);
        }
    }
}
