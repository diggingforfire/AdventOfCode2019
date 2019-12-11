using System;
using System.IO;
using System.Linq;

namespace _01._02
{
    class Program
    {
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
