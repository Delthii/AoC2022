using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day03
    {
        public Day03(string[] input)
        {
            A(input);
            B(input);
        }
        
        private static void A(string[] input)
        {
            var sum = 0;
            foreach (var row in input)
            {
                var comp1 = row.Substring(0, row.Length / 2).ToHashSet();
                var comp2 = row.Substring(row.Length / 2).ToHashSet();
                var item = comp1.Intersect(comp2).Single();
                sum += GetPrio(item);
            }

            Console.WriteLine(sum);
        }
        private static void B(string[] input)
        {
            var sum = ChunkIt(input, 3)
                .Select(g => g[0].Intersect(g[1]).Intersect(g[2]).Single())
                .Sum(GetPrio);

            Console.WriteLine(sum);
        }

        private static IEnumerable<HashSet<char>[]> ChunkIt(IEnumerable<string> input, int chunkSize)
        {
            return input
                .Select(s => s.ToHashSet())
                .Select((s, i) => (s, i))
                .GroupBy(t => t.i / chunkSize)
                .Select(g => g.Select(gg => gg.s).ToArray());
        }

        private static int GetPrio(char item)
        {
            if (char.IsLower(item))
            {
                return item - 'a' + 1;
            }
            else
            {
                return item - 'A' + 27;
            }
        }

        public Day03(string input)
        {
            
        }
    }
}
