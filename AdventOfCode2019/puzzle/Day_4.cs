using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2019.puzzle
{
    class Day_4
    {

        public static int Puzzle1()
        {
            //It is a six-digit number.
            //The value is within the range given in your puzzle input.
            //Two adjacent digits are the same (like 22 in 122345).
            //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).

            // range 254032-789860

            IEnumerable<string> possibilities = Enumerable.Range(1, 9).Select(p => p.ToString() + p.ToString());

            int start = 254032;
            int end = 789860;

            int matches = 0;

            for (int i = start; i < end; i++)
            {
                var iString = i.ToString();
                if (possibilities.Any(w => iString.Contains(w)))
                {
                    bool ok = true;
                    for (int j = 1; j < iString.Length; j++)
                    {
                        if (iString[j] < iString[j - 1])
                        {
                            ok = false;
                        }
                    }
                    if (!ok)
                    {
                        continue;
                    }
                    matches++;
                }
            }
            return matches;
        }

        public static int Puzzle2()
        {
            // extra rule: repeated digits cannot be part of a larger group of matching digits
            // so 112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
            // 123444 no longer meets the criteria(the repeated 44 is part of a larger group of 444).
            // 111122 meets the criteria(even though 1 is repeated more than twice, it still contains a double 22).
            // range 254032-789860

            // make a list of numbers (4-digits) that contain 1 double digit in the center e.g. x11x, x22x, x33x, .., x99x, where x != [1] but == [2]
            IEnumerable<string> allPos = Enumerable.Range(1111, 9999).Select(p => p.ToString()).Where(p => p[0] != p[1] && p[3] != p[1] && p[1] == p[2]);

            int start = 254032;
            int end = 789860;

            int matches = 0;

            for (int i = start; i < end; i++)
            {
                var iString = i.ToString();

                // the number can contain a double digit (== number in allPos), can start with the double digit (substring(1) - 223) or can end with the double digit (substring(0,3) - eg 988)
                // 25566 (ends with double digit)
                // 255666 (has double digit)
                // 334444 (begins with double digit)
                if (allPos.Any(w => iString.Contains(w) || iString.StartsWith(w.Substring(1)) || iString.EndsWith(w.Substring(0, 3))))
                {
                    bool ok = true;
                    for (int j = 1; j < iString.Length; j++)
                    {
                        if (iString[j] < iString[j - 1])
                        {
                            ok = false;
                        }
                    }
                    if (!ok)
                    {
                        continue;
                    }
                    Console.WriteLine(i);
                    matches++;
                }
            }
            return matches;
        }
    }
}