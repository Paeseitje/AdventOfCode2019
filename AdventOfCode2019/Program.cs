using AdventOfCode2019.puzzle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    class Program : LoadData
    {
        public const string INPUT_FILE_DIR = "input";

        static void Main(string[] args)
        {
            int day = 3;
            var solve1 = Day_3.Solve1();
            Console.WriteLine("Solution to puzzle 1 of day {0}: {1}", day, solve1);
            //int solve2 = Day_4.Puzzle2();
            //Console.WriteLine("Solution to puzzle 2 of day {0}: {1}", day, solve2);
        }
    }
}
