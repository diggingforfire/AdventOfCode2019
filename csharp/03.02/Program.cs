using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._02
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/3#part2
        /// Simple addition to part 1.
        /// Instead of calculating the Manhattan distance, count the amount of steps.
        /// </summary>
        static void Main()
        {
            var wires =
                File.ReadAllLines("input.txt")
                .Select(line => line.Split(','))
                .Select(wireParts =>
                    wireParts.Select(wirePart =>
                    new
                    {
                        Direction = wirePart[0],
                        Count = int.Parse(wirePart.Substring(1))
                    }))
                .Select(wireParts =>
                {
                    int x = 0, y = 0;
                    var points = new List<(int X, int Y)>();

                    foreach (var wirePart in wireParts)
                    {
                        for (int i = 0; i < wirePart.Count; i++)
                        {
                            switch (wirePart.Direction)
                            {
                                case 'U': y++;
                                    break;
                                case 'D': y--;
                                    break;
                                case 'L': x--;
                                    break;
                                case 'R': x++;
                                    break;
                            }

                            points.Add((x, y));
                        }
                    }
                    return points;
                }).ToList();

            var result = wires[0].Intersect(wires[1]).Min(i => wires[0].IndexOf(i) + wires[1].IndexOf(i) + 2);

            Console.WriteLine(result);
        }
    }
}
