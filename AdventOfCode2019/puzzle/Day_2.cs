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
            List<int> input = LoadDataAsIntList_2(2);

            input[1] = 12;
            input[2] = 2;

            int result = Calculate(input);
            return result;
        }

        //public static string Puzzle2()
        //{

        //    List<int> input = LoadDataAsIntList_2(2);
        //    input[1] = 12;
        //    input[2] = 2;

        //    int expected = 19690720;        

        //    int result = Calculate(input);
        //    // find the noun: add 1 to noun untill value is more then the expected value. subtracting 1 gives us the noun.
        //    while (result < expected)
        //    {
        //        input[1]++;
        //        result = Calculate(input);
        //    }

        //    input[1]--;
        //    int noun = input[1];

        //    // find the verb: add 1 to verb untill we find the exact match
        //    result = Calculate(input);
        //    while (result != expected)
        //    {
        //        input[2]++;
        //        result = Calculate(input);
        //    }

        //                int verb = input[2];

        //    string duo = noun.ToString() + verb.ToString();
        //    return duo;
        //}

        public static int Puzzle2()
        {
            int answer = 0;
            int expected = 19690720;

            Enumerable.Range(0, 99).ToList().ForEach(noun =>
            {
                Enumerable.Range(0, 99).ToList().ForEach(verb =>
                {
                    List<int> input = LoadData.LoadDataAsIntList_2(2);
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
