namespace AoC2022
{
    internal class Day01
    {
        public Day01(string input)
        {
            var a = input.Split("\r\n\r\n").Select(e => e.Split("\r\n").Select(int.Parse)).Max(e => e.Sum());
            var b = input.Split("\r\n\r\n").Select(e => e.Split("\r\n").Select(int.Parse)).OrderByDescending(e => e.Sum()).Take(3).SelectMany(e => e).Sum();
        }

        public Day01(string[] input)
        {
            var elves = new List<Elf>();
            var elf = new Elf();
            foreach(var row in input)
            {
                if(row.Length == 0)
                {
                    elves.Add(elf);
                    elf = new Elf();
                }
                else
                {
                    elf.Add(int.Parse(row));
                }
            }
            elves.Add(elf);

            var sorted = elves.OrderByDescending(e => e.Total()).Take(3);
            Console.WriteLine(sorted.First().Total());
            Console.WriteLine(sorted.Sum(e => e.Total()));
        }

        class Elf
        {
            List<int> Calories = new();

            public void Add(int cal)
            {
                Calories.Add(cal);
            }

            public int Total()
            {
                return Calories.Sum();
            }
        }
    }
}
