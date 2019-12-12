using System;
using System.Linq;

namespace _04._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/4
        /// This reminded me of the versatility of Linq and Zip in particular which is just the best name for a method ever.
        /// </summary>
        static void Main()
        {
            int from = 134792;
            int to = 675810;

            var count = 
                Enumerable
                .Range(from, to - from)
                .Select(i => i.ToString())
                .Select(s => s.Zip(s.Substring(1)).ToArray())
                .Count(pairs => 
                    pairs.Any(pair => pair.First == pair.Second) && 
                    pairs.All(pair => pair.Second >= pair.First));

            Console.WriteLine(count);
        }
    }
}
