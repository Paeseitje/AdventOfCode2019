using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            int matches = 0;

            for ( int number = 254032; number != 789860; number++)
            {
                // check if the number is compliant
                // if all digits increase and if 2 adjecent digits are the same
                // then add add 1 to matches.

                var test = CheckAllDigitsIncrease(number);
                if (test == true)
                {
                    matches++;
                }

            }
            return matches;

        }

        public static bool CheckAllDigitsIncrease(int number)
        {
            {
                string text = number.ToString();
                char previous = '0';

                foreach (char c in text)
                {
                    if (c <= previous)
                        return false;
                    previous = c;
                }

                return true;
            }
        }
    }
}
