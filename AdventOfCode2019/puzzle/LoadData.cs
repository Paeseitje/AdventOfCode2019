using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode2019.puzzle
{
    class LoadData
    {
        protected static string GetPath( int day)
        {
            return String.Format("{0}/day_{1}.txt", Program.INPUT_FILE_DIR, day);
        }

        // load data as a list<int>
        protected static List<int> LoadDataAsIntList(int day)
        {
            List<int> input = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        input.Add(int.Parse(sr.ReadLine()));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return input;
        }

        protected static List<int> LoadDataAsIntList_2 (int day)
        {
            List<int> input = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(GetPath(day)))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        input = line.Split(',').Select(int.Parse).ToList();

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return input;
        }
    }
}
