using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day04
    {
        public Day04(string[] input)
        {
            A(input);
            B(input);
        }

        private static void B(string[] input)
        {
            var sum = 0;
            foreach (var row in input)
            {
                var pairs = row.Split(",");
                var p1 = pairs[0].Split("-").Select(int.Parse).ToArray();
                var p2 = pairs[1].Split("-").Select(int.Parse).ToArray();
                var hs1 = Enumerable.Range(p1[0], p1[1] - p1[0] + 1);
                var hs2 = Enumerable.Range(p2[0], p2[1] - p2[0] + 1);
                if (hs1.Intersect(hs2).Count() > 0)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }

        private static void A(string[] input)
        {
            var sum = 0;
            foreach (var row in input)
            {
                var pairs = row.Split(",");
                var p1 = pairs[0].Split("-").Select(int.Parse).ToArray();
                var p2 = pairs[1].Split("-").Select(int.Parse).ToArray();
                if (p1[0] >= p2[0] && p1[1] <= p2[1])
                {
                    sum++;
                }
                else if (p2[0] >= p1[0] && p2[1] <= p1[1])
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
