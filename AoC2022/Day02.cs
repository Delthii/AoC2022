using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day02
    {
        public Day02(string[] input)
        {
            A(input);
            var points = 0;
            foreach (var row in input)
            {
                var split = row.Split();
                var h1 = ToHand(split[0]);
                int point = 0;
                if (h1 == Hand.Rock)
                {
                    if (split[1] == "X")
                    {
                        point = 3;
                    }
                    if (split[1] == "Y")
                    {
                        point = 1 + 3;
                    }
                    if (split[1] == "Z")
                    {
                        point = 2 + 6;
                    }
                }
                if (h1 == Hand.Paper)
                {
                    if (split[1] == "X")
                    {
                        point = 1;
                    }
                    if (split[1] == "Y")
                    {
                        point = 2 + 3;
                    }
                    if (split[1] == "Z")
                    {
                        point = 3 + 6;
                    }
                }
                if (h1 == Hand.Sissors)
                {
                    if (split[1] == "X")
                    {
                        point = 2;
                    }
                    if (split[1] == "Y")
                    {
                        point = 3 + 3;
                    }
                    if (split[1] == "Z")
                    {
                        point = 1 + 6;
                    }
                }
                points += point;
            }

            Console.WriteLine(points);
        }
        private void A(string[] input)
        {
            int points = 0;
            foreach (var row in input)
            {
                var split = row.Split();
                var h1 = ToHand(split[0]);
                var h2 = ToHand(split[1]);
                int point = (int)h2;
                if (h1 == h2)
                {
                    point += 3;
                }
                else if (h1 == Hand.Sissors && h2 == Hand.Rock)
                {
                    point += 6;
                }
                else if (h1 == Hand.Rock && h2 == Hand.Paper)
                {
                    point += 6;
                }
                else if (h1 == Hand.Paper && h2 == Hand.Sissors)
                {
                    point += 6;
                }
                points += point;
            }

            Console.WriteLine(points);
        }

        Hand ToHand(string str)
        {
            if (str == "X" || str == "A") return Hand.Rock;
            if (str == "Y" || str == "B") return Hand.Paper;
            if (str == "Z" || str == "C") return Hand.Sissors;

            throw new Exception("Incorrect string!");
        }

        public Day02(string input)
        {
            
        }
    }

    enum Hand
    {
        Rock = 1, Paper = 2, Sissors = 3,
    }
}
