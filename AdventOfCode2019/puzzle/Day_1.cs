using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.puzzle
{
    class Day_1 : LoadData
    {
        public static int Puzzle1()
        {
            var modules = LoadData.LoadDataAsIntList(1);

            int sum = 0;

            foreach (int module in modules)
            {
                int fuel = Calc_fuel(module);
                sum += fuel;
            }

            return sum;
        }

        public static int Puzzle2()
        {
            var modules = LoadData.LoadDataAsIntList(1);

            int sum = 0;

            foreach (int module in modules)
            {
                int fuel = Calc_fuel(module);
                while (fuel > 0)
                {
                    sum += fuel;
                    fuel = Calc_fuel(fuel);
                }
            }

            return sum;
        }

        public static int Calc_fuel(int module)
        {
            float amount = module / 3;
            int rounded = (int)Math.Floor(amount);
            int fuel = rounded - 2;
            return fuel;
        }
    }

}