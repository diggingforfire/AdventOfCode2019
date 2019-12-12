using System;
using System.Linq;
using System.Drawing;
using System.IO;

namespace _10._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/10
        /// Took to me some time to let it sink in that we're just dealing with triangles and angles here.
        /// They see me rolling, they atan
        /// </summary>
        static void Main()
        {
            var points =
                File.ReadAllLines("input.txt")
                .Select((line, y) => line.Select((@char, x) => new { @char, x, y })
                .Where(point => point.@char == '#')).SelectMany(points => points).Select(point => new Point(point.x, point.y)).ToArray();

            int result = points.Max(point => points.Count(otherPoint => point != otherPoint && HasLineOfSight(point, otherPoint, points)));

            Console.WriteLine(result);
        }

        static int GetManhattanDistance(Point point, Point otherPoint)
        {
            return Math.Abs(point.X - otherPoint.X) + Math.Abs(point.Y - otherPoint.Y);
        }

        static bool HasLineOfSight(Point point, Point otherPoint, Point[] points)
        {
            var angle = Math.Atan2(point.Y - otherPoint.Y, point.X - otherPoint.X);

            // Line of sight means there are no other points with the same angle that have a smaller Manhattan distance
            return !points.Any(p => 
                p != point && 
                p != otherPoint && 
                Math.Atan2(point.Y - p.Y, point.X - p.X) == angle && 
                GetManhattanDistance(point, p) < GetManhattanDistance(point, otherPoint));
        }
    }
}
