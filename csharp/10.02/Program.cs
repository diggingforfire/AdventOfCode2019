using System;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;

namespace _10._02
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/10#part2
        /// I really wanted to determine the order of asteroids here by chaining Linq statements.
        /// Going clockwise wasn't the hard part (order by angle), rather skipping to the next closest one took some GroupBy abuse.
        /// </summary>
        static void Main()
        {
            var points =
                File.ReadAllLines("input.txt")
                .Select((line, y) => line.Select((@char, x) => new { @char, x, y })
                .Where(point => point.@char == '#')).SelectMany(points => points).Select(point => new Point(point.x, point.y)).ToArray();

            var monitoringStation = points.OrderByDescending(point => points.Count(otherPoint => 
                point != otherPoint && 
                HasLineOfSight(point, otherPoint, points))).First();

            // Order all points by their angle as opposed to the monitoring station, secondly order by manhattan distance
            // then group them all by angle
            // then ungroup them again with SelectMany, but save the index of that point within the group
            // finally, order the full list of points by their index within their group
            var orderedPoints = points.Where(point => point != monitoringStation).Select(point => new
                {
                    Point = point,
                    ManhattanDistance = GetManhattanDistance(monitoringStation, point),
                    Angle = GetAngleInDegrees(monitoringStation, point, -90) // offset 90 to adjust for looking up
                }).OrderBy(p => p.Angle).ThenBy(p => p.ManhattanDistance).GroupBy(p => p.Angle)
                .SelectMany(g => g.Select((p, i) => new {p, i}))
                .OrderBy(p => p.i)
                .ToList();


            //int result = orderedPoints[199].p.Point.X * 100 + orderedPoints[199].p.Point.Y;
            //Console.WriteLine(result);

            var map = File.ReadAllLines("input.txt").Select((line, y) => line.Select((@char, x) => (new Point(x, y), @char)).ToArray()).ToArray();
            var targets = orderedPoints.Select(p => p.p.Point).ToArray();
            VaporizeAll(map, targets, monitoringStation);
            Console.ReadKey();
            Console.CursorVisible = false;
        }

        static void VaporizeAll((Point point, char @char)[][] map, Point[] targets, Point monitoringStation, int zapIntervalInMs = 100, int margin = 5)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            DrawTitle("COMMENCING DESTRUCTION", margin + 2, margin / 2, ConsoleColor.DarkGray);
            DrawMap(map, margin);

            DrawPoint(monitoringStation, "◙", ConsoleColor.Blue, margin);

            foreach (var target in targets)
            {
                AnimateDestruction(target, margin);
                Thread.Sleep(zapIntervalInMs);
            }

            DrawTitle("DESTRUCTION COMPLETE  ", margin + 2, margin / 2, ConsoleColor.DarkGray);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void DrawTitle(string title, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            int oldX = Console.CursorLeft;
            int oldY = Console.CursorTop;

            Console.CursorLeft = x;
            Console.CursorTop = y;
            
            Console.Write(title);

            Console.CursorLeft = oldX;
            Console.CursorTop = oldY;
        }

        static void AnimateDestruction(Point target, int margin, int animationIntervalInMs = 15)
        {
            var colors = new[] {ConsoleColor.DarkYellow, ConsoleColor.DarkYellow, ConsoleColor.Yellow, ConsoleColor.Yellow, ConsoleColor.DarkRed, ConsoleColor.Red};

            foreach (var color in colors)
            {
                DrawPoint(target, "#", color, margin);
                Thread.Sleep(animationIntervalInMs);
            }

            var strings = new[] { "*", "."};

            foreach (var str in strings)
            {
                DrawPoint(target, str, Console.ForegroundColor, margin);
                Thread.Sleep(animationIntervalInMs);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            DrawPoint(target, strings.Last(), Console.ForegroundColor, margin);
        }

        static void DrawMap((Point point, char @char)[][] map, int margin)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < margin; i++)
            {
                Console.WriteLine();
            }

            foreach (var row in map)
            {
                for (int i = 0; i < margin * 2; i++)
                {
                    Console.Write(' ');
                }

                foreach (var point in row)
                {
                    Console.Write(point.@char);
                }

                Console.WriteLine();
            }
        }

        public static void PewPew()
        {
            Process.Start(@"powershell", $@"-c  Add-Type -AssemblyName presentationCore; $p = New-Object System.Windows.Media.MediaPlayer; $p.Open('C:\Go\test.mp3'); $p.Play();");
        }

        static void DrawPoint(Point point, string text, ConsoleColor color, int margin)
        {
            Console.ForegroundColor = color;
            Console.CursorTop = point.Y + margin;
            Console.CursorLeft = point.X + margin * 2;
            Console.Write(text);
        }

        static double GetAngleInDegrees(Point point, Point otherPoint, int offsetDegrees)
        {
            var angle = Math.Atan2(point.Y - otherPoint.Y, point.X - otherPoint.X) * 180 / Math.PI;

            angle += offsetDegrees;

            if (angle < 0)
            {
                angle += 360;
            }

            return angle;

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
