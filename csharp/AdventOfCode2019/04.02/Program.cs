using System;
using System.Linq;

namespace _04._02
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/4#part2
        /// No more zipping, but Skip combined with Select is quite nice for selecting portions.
        /// </summary>
        static void Main()
        {
            int from = 134792;
            int to = 675810;

            var count =
                Enumerable
                .Range(from, to - from)
                .Select(i => i.ToString())
                .Select(s => s.Skip(1).Select((@char, index) => new
                {
                    Pair = new
                    {
                        First = s[index],
                        Second = @char
                    },
                    Previous = index - 1 >= 0 ? s[index - 1] : ' ',
                    Next = index + 2 <= s.Length - 1 ? s[index + 2] : ' '
                }).ToArray())
                .Count(pairs =>
                    pairs.Any(pair => pair.Pair.First == pair.Pair.Second && pair.Pair.First != pair.Previous && pair.Pair.First != pair.Next) &&
                    pairs.All(pair => pair.Pair.Second >= pair.Pair.First));

            Console.WriteLine(count);
        }
    }
}
