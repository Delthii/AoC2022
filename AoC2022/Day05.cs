using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day05
    {
        public Day05(string[] input)
        {
            A(input);
            B(input);
        }
        private static void A(string[] input)
        {
            Stack<char>[] stacks;
            int startIndex;
            Init(input, out stacks, out startIndex);

            foreach (var row in input.Skip(startIndex))
            {
                var split = row.Split(' ');
                var move = int.Parse(split[1]);
                var from = int.Parse(split[3]) - 1;
                var to = int.Parse(split[5]) - 1;

                for (int i = 0; i < move; i++)
                {
                    var crate = stacks[from].Pop();
                    stacks[to].Push(crate);
                }
            }

            PrintTopCrates(stacks);
        }

        private static void B(string[] input)
        {
            Stack<char>[] stacks;
            int startIndex;
            Init(input, out stacks, out startIndex);

            foreach (var row in input.Skip(startIndex))
            {
                var split = row.Split(' ');
                var move = int.Parse(split[1]);
                var from = int.Parse(split[3]) - 1;
                var to = int.Parse(split[5]) - 1;

                var l = new Stack<char>(stacks[from].Take(move));
                foreach (var c in l)
                {
                    stacks[from].Pop();
                    stacks[to].Push(c);
                }
            }

            PrintTopCrates(stacks);
        }

        private static void PrintTopCrates(Stack<char>[] stacks)
        {
            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                {
                    Console.Write(stack.Peek());
                }
                else
                {
                    Console.Write(" ");

                }
            }
            Console.WriteLine();
        }
        
        private static void Init(string[] input, out Stack<char>[] stacks, out int startIndex)
        {
            stacks = new Stack<char>[9];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>();
            }
            startIndex = 0;
            foreach (var row in input)
            {
                startIndex++;
                if (row.Length == 0)
                {
                    break;
                }

                for (int i = 1, stack = 0; i < row.Length; i += 4, stack++)
                {
                    if (row[i] >= 'A' && row[i] <= 'Z')
                    {
                        stacks[stack].Push(row[i]);
                    }
                }
            }
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>(stacks[i]);
            }
        }
    }
}
