using System;
using System.Collections.Generic;
using System.Linq;
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

            List<int> range = Enumerable.Range(122345, 122351).ToList();
            int n = range.Count();

            List<int> IncreasingNumbers = CheckAllDigitsInrease(range, n);

            List<int> compliantList = new List<int>();

            foreach (int nmbr in IncreasingNumbers)
            {
                if (HasDoubleDigits(nmbr) == true)
                {
                    compliantList.Add(nmbr);
                }
            }
            // count List
            int matches = compliantList.Count;
            return matches;
        }

        public static bool HasDoubleDigits (int number)
        {
            String numberToCheck = number.ToString();
            bool contains = Regex.IsMatch(numberToCheck, @"22");

            return contains;
        }

        public static List<int> CheckAllDigitsInrease (List<int> IntList, int n)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i < n - 1; i++)
            {
                if (IntList[i] < IntList[i - 1])
                {
                    numbers.Add(IntList[i]);
                }
            }
            return IntList;
        }

        public static List<int> GetIntList(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num /= 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToList();
        }
    }
}