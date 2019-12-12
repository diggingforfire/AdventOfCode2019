using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06._01
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/6
        /// More recursion. A dictionary makes this quite straightforward.
        /// </summary>
        static void Main()
        {
            var mapData =
                File.ReadAllLines("input.txt")
                .Select(line => line.Split(')'))
                .ToDictionary(line => line[1], line => line[0]);

            int total = mapData.Sum(kvp => GetOrbits(kvp.Key, mapData).Count);

            Console.WriteLine(total);
        }

        static List<string> GetOrbits(string objectName, Dictionary<string, string> mapData, List<string> orbits = null)
        {
            orbits ??= new List<string>(); 

            if (!mapData.ContainsKey(objectName))
            {
                return orbits;
            }
         
            var orbitedObject = mapData[objectName];
            orbits.Add(orbitedObject);

            return GetOrbits(orbitedObject, mapData, orbits);       
        }
    }
}
