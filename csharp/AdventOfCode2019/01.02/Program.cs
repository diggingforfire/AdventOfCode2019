using System;
using System.IO;
using System.Linq;

namespace _01._02
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/1#part2
        /// A bit more interesting than part 2. Lends itself to recursion.
        /// The base case is determined by using the precomputed fact that an input lower than 9 will lead to 0 output.
        /// </summary>
        static void Main()
        {
            var result = File.ReadAllLines("input.txt").Select(int.Parse).Sum(GetFuel);

            Console.WriteLine(result);
        }

        static int GetFuel(int mass)
        {
            int fuel = mass / 3 - 2;

            if (fuel >= 9)
            {
                return fuel + GetFuel(fuel);
            }

            return fuel;
        }
    }
}
