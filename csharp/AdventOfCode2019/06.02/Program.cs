using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06._02
{
    class Program
    {
        /// <summary>
        /// https://adventofcode.com/2019/day/6#part2
        /// I stayed up way too late figuring out the approach for this one, a worthy part 2.
        /// Start at "YOU", then check all your moons. It it doesn't contain "SAN", go to the object you orbit and repeat.
        /// If it does contain "SAN", backtrack from "SAN" to the source moon.
        /// </summary>
        static void Main()
        {
            var mapData =
                File.ReadAllLines("input.txt")
                .Select(line => line.Split(')'))
                .ToDictionary(line => line[1], line => line[0]);

            int transferCount = GetTransfers("YOU", "SAN", mapData).Count - 1;
            
            Console.WriteLine(transferCount);

        }

        static List<string> GetTransfers(string start, string end, Dictionary<string, string> allObjects, string source = null, List<string> orbits = null)
        {
            orbits ??= new List<string>();

            var moons = GetMoons(start, allObjects, source);

            if (moons.Contains(end))
            {
                var orbitsBetweenSantaAndStart = GetOrbits("SAN", start, allObjects);
                orbits.AddRange(orbitsBetweenSantaAndStart);
                return orbits;
            }

            var orbitedObject = allObjects[start];
            orbits.Add(orbitedObject);
            return GetTransfers(orbitedObject, end, allObjects, start, orbits);
        }

        static List<string> GetMoons(string objectName, Dictionary<string, string> allObjects, string source = null, List<string> moons = null)
        {
            moons ??= new List<string>();

            var foundMoons = allObjects.Where(o => o.Value == objectName && o.Key != source);

            foreach (var moon in foundMoons)
            {
                moons.Add(moon.Key);
                GetMoons(moon.Key, allObjects, source, moons);
            }

            return moons;
        }

        static List<string> GetOrbits(string @objectName, string stopAt, Dictionary<string, string> allObjects, List<string> orbits = null)
        {
            orbits ??= new List<string>();

            var orbitedObject = allObjects[objectName];

            if (!allObjects.ContainsKey(objectName) || orbitedObject == stopAt)
            {
                return orbits;
            }

            orbits.Add(orbitedObject);

            return GetOrbits(orbitedObject, stopAt, allObjects, orbits);
        }
    }
}
