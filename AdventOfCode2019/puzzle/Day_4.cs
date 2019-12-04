using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.puzzle
{
    class Day_4
    {

        public static Stack<int> Puzzle1()
        {
            //It is a six-digit number.
            //The value is within the range given in your puzzle input.
            //Two adjacent digits are the same (like 22 in 122345).
            //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).

            // range 254032-789860

            int matches;

            for ( int number = 254032; number != 789860; number++)
            {
                // check if the number is compliant
                // if all digits increase and if 2 adjecent digits are the same
                // then add add 1 to matches.


            }

        }

        public static bool CheckAllDigitsIncrease(int number)
        {
            List<int> digits = GetNumberDigits(number);

            bool increasing;

            for (int i = 0; i <= digits.Count; i++)
            {
                if (digits[i] < digits[i + 1])
                {
                    increasing = true;
                }
                else
                {
                    increasing = false;
                }
            return increasing;
            }
        }


        public static List<int> GetNumberDigits (int number)
        {
            var digits = GetNumberDigits(number / 10);
            digits.Insert(0, number % 10);

            return digits;
        }
    }
}
