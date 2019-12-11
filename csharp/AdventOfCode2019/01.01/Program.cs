using System;
using System.IO;
using System.Linq;

namespace _01._01
{
    class Program
    {
        static void Main()
        {
            var result = File.ReadAllLines("input.txt").Select(int.Parse).Sum(mass => mass / 3 - 2);

            Console.WriteLine(result);
        }
    }
}
