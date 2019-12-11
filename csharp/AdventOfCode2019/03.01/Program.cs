using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/3
        /// 
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
            
            var result = wires[0].Intersect(wires[1]).Min(i => Math.Abs(i.X) + Math.Abs(i.Y));
                
            Console.WriteLine(result);
        }
    }
}
