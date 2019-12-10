using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.puzzle
{
    class Day_3 : LoadData
    {
        // make a list of coordinates for both wires
        // check were both list have the same coordinates
        // calculate manhatten distance for each of the intersections
        // return the smallest distance

        public static int Puzzle1()
        {

            var coordinates = new List<List<Coordinate>>() { new List<Coordinate>(), new List<Coordinate>() };
            int index = 0;

            List<List<string>> input = LoadDataListAsStringListList(3);


            foreach (List<string> wire in input)
            {
                int x = 0;
                int y = 0;

                foreach (string loc in wire)
                {
                    switch (loc[0])
                    {
                        case 'R':
                            List<int> R = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                            foreach (int r in R)
                            {
                                coordinates[index].Add(new Coordinate(x++, y));
                            }
                            break;

                        case 'U':
                            var U = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                            foreach (int u in U)
                            {
                                coordinates[index].Add(new Coordinate(x, y++));
                            }
                            break;

                        case 'L':
                            var L = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                            foreach (int l in L)
                            {
                                coordinates[index].Add(new Coordinate(x--, y));
                            }
                            break;

                        case 'D':
                            var D = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                            foreach (int d in D)
                            {
                                coordinates[index].Add(new Coordinate(x, y--));
                            }
                            break;
                        default:
                            break;
                    }
                }
                index++;

            }

            List<Coordinate> intersections = coordinates[0].Intersect(coordinates[1]).Except(new List<Coordinate>() { new Coordinate(0, 0) }).ToList();

            //return coordinates[0].Intersect(coordinates[1]).Except(new List<Coordinate>() { new Coordinate(0, 0) }).ToList().Min(i => Math.Abs(i.x) + Math.Abs(i.y)).ToString();


            // check for crossing points
            //var intersections = coordinates[0].Intersect(coordinates[1]);

            //foreach ( var i in intersections)
            //{
            //    Console.WriteLine(i);
            //}

            // calculate manhatten distance
            List<int> distances = new List<int>();
            //Coordinate start = new Coordinate(0, 0);

            foreach (var i in intersections)
            {
                var distance = Math.Abs(i.x) + Math.Abs(i.y);
                distances.Add(distance);
            }

            // return the min value in the list
            int lowestDistance = distances.Min();
            return lowestDistance;

        }

        public static string Solve1()
        {
            int index = 0;
            List<List<Coordinate>> locations = new List<List<Coordinate>>() { new List<Coordinate>(), new List<Coordinate>() };
            LoadDataListAsStringListList(3).ForEach(s =>
            {
                int x = 0,
                    y = 0;
                s.ForEach(t =>
                {
                    switch (t.First())
                    {
                        case 'R':
                            Enumerable.Range(0, int.Parse(t.Substring(1))).ToList().ForEach(i => locations[index].Add(new Coordinate(x++, y)));
                            break;
                        case 'L':
                            Enumerable.Range(0, int.Parse(t.Substring(1))).ToList().ForEach(i => locations[index].Add(new Coordinate(x--, y)));
                            break;
                        case 'D':
                            Enumerable.Range(0, int.Parse(t.Substring(1))).ToList().ForEach(i => locations[index].Add(new Coordinate(x, y--)));
                            break;
                        case 'U':
                            Enumerable.Range(0, int.Parse(t.Substring(1))).ToList().ForEach(i => locations[index].Add(new Coordinate(x, y++)));
                            break;
                    }
                });
                index++;
            });

            return locations[0].Intersect(locations[1]).Except(new List<Coordinate>() { new Coordinate(0, 0) }).ToList().Min(i => Math.Abs(i.x) + Math.Abs(i.y)).ToString();
        }


        public static int ManhattanDistance(Coordinate one, Coordinate two)
        {
            return Math.Abs(one.x - two.x) + Math.Abs(one.y - one.y);
        }

        public class Coordinate
        {
            public int x;
            public int y;

            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
