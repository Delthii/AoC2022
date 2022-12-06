using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day06
    {
        public Day06(string[] input)
        {
            A(input);
            B(input);
        }
        private static void A(string[] input)
        {
            var msg = input.Single();
            for (int i = 0; i < msg.Length - 4; i++)
            {
                var hs = new HashSet<char>(new char[] { msg[i], msg[i + 1], msg[i + 2], msg[i + 3] });
                if (hs.Count() == 4)
                {
                    Console.WriteLine(i + 4);
                    break;
                }
            }
        }

        private static void B(string[] input)
        {
            var msg = input.Single();
            for (int i = 0; i < msg.Length - 14; i++)
            {
                var hs = new HashSet<char>(msg.Skip(i).Take(14));
                if (hs.Count() == 14)
                {
                    Console.WriteLine(i + 14);
                    break;
                }
            }
        }        
    }
}
