using System;
using System.IO;
using System.Linq;

namespace _01._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/1
        /// Pretty straightforward. Rounding down is accomplished by just dividing integers.
        /// </summary>
        static void Main()
        {
            var result = File.ReadAllLines("input.txt").Select(int.Parse).Sum(mass => mass / 3 - 2);

            Console.WriteLine(result);
        }
    }
}
