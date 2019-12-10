using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.puzzle
{
    class Day_2 : LoadData
    {
        public static int Puzzle1()
        {
            List<int> input = LoadDataListAsIntList(2);

            input[1] = 12;
            input[2] = 2;

            int result = Calculate(input);
            return result;
        }

        public static int Puzzle2()
        {
            int answer = 0;
            int expected = 19690720;

            Enumerable.Range(0, 99).ToList().ForEach(noun =>
            {
                Enumerable.Range(0, 99).ToList().ForEach(verb =>
                {
                    List<int> input = LoadDataListAsIntList(2);
                    input[1] = noun;
                    input[2] = verb;

                    int result = Calculate(input);

                    if (result == expected)
                    {
                        answer = 100 * noun + verb;
                    }
                });
            });
            return answer;
        }

        public static int Calculate(List<int> numbers)
        {
            int counter = 0;
            while (true)
            {
                int opcode = numbers[counter];

                switch (opcode)
                {
                    case 1:
                        // add numbers (1,2) and store in (3)
                        int value_1 = numbers[numbers[counter + 1]];
                        int value_2 = numbers[numbers[counter + 2]];
                        int replace_pos = numbers[counter + 3];
                        numbers[replace_pos] = value_1 + value_2;
                        counter += 4;
                        break;
                    case 2:
                        // multiply numbers (1,2) and store in (3)
                        value_1 = numbers[numbers[counter + 1]];
                        value_2 = numbers[numbers[counter + 2]];
                        replace_pos = numbers[counter + 3];
                        numbers[replace_pos] = value_1 * value_2;
                        counter += 4;
                        break;
                    case 99:
                        // program stops and returns adress 0 of list
                        return numbers[0];
                    default:
                        // when a unknown opcode is encountered 
                        break;
                }
            }
        }
    }
}
