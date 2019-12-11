using System;
using System.Collections.Generic;
using System.IO;
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
            List<string> wire_1 = File.ReadLines("input/day_3.txt").ElementAtOrDefault(0).Split(',').ToList();
            List<string> wire_2 = File.ReadLines("input/day_3.txt").ElementAtOrDefault(1).Split(',').ToList();

            List<Coordinate> locations_wire1 = GetCoordinates(wire_1);
            List<Coordinate> locations_wire2 = GetCoordinates(wire_2);

            var wire1_points = new List<string>();
            var wire2_points = new List<string>();

            foreach (var l in locations_wire1)
            {
                string point = String.Format("{0}^{1}", l.x, l.y);
                wire1_points.Add(point);
                //Console.WriteLine("X = {0}, Y = {1}", l.x, l.y);
            }

            foreach (var l in locations_wire2)
            {
                string point = String.Format("{0}^{1}", l.x, l.y);
                wire2_points.Add(point);
                //Console.WriteLine("X = {0}, Y = {1}", l.x, l.y);
            }


            //List<Coordinate> intersections = coordinates[0].Intersect(coordinates[1]).Except(new List<Coordinate>() { new Coordinate(0, 0) }).ToList();

            //return coordinates[0].Intersect(coordinates[1]).Except(new List<Coordinate>() { new Coordinate(0, 0) }).ToList().Min(i => Math.Abs(i.x) + Math.Abs(i.y)).ToString();


            // check for crossing points




            List<string> intersections = wire1_points.Intersect(wire2_points).ToList();
            List<Coordinate> intersecting_coordinates = new List<Coordinate>();

            foreach (string intersect in intersections)
            {
                var point = intersect.Split('^');
                intersecting_coordinates.Add(new Coordinate(int.Parse(point[0]), int.Parse(point[1])));
            }

            // calculate manhatten distance
            List<int> distances = new List<int>();
            //Coordinate start = new Coordinate(0, 0);

            foreach (var i in intersecting_coordinates)
            {
                var distance = Math.Abs(i.x) + Math.Abs(i.y);
                distances.Add(distance);
            }

            // return the min value in the list
            distances.RemoveAt(0);
            int lowestDistance = distances.Min();
            return lowestDistance;
        }



        public static List<Coordinate> GetCoordinates(List<string> locations)
        {
            var wire_locations = new List<Coordinate>();

            int x = 0;
            int y = 0;

            foreach (string loc in locations)
            {
                switch (loc[0])
                {
                    case 'R':
                        List<int> R = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                        foreach (int r in R)
                        {
                            wire_locations.Add(new Coordinate(x++, y));
                        }
                        break;

                    case 'U':
                        var U = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                        foreach (int u in U)
                        {
                            wire_locations.Add(new Coordinate(x, y++));
                        }
                        break;

                    case 'L':
                        var L = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                        foreach (int l in L)
                        {
                            wire_locations.Add(new Coordinate(x--, y));
                        }
                        break;

                    case 'D':
                        var D = Enumerable.Range(0, int.Parse(loc.Substring(1))).ToList();
                        foreach (int d in D)
                        {
                            wire_locations.Add(new Coordinate(x, y--));
                        }
                        break;
                    default:
                        break;
                }
            }
            return wire_locations;
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
