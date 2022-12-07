namespace AoC2022
{
    internal partial class Day07
    {
        public Day07(string[] input)
        {
            A(input);
            B(input);
        }

        private static void A(string[] input)
        {
            IFileSystem fs = FileSystem.SetUpFileSystem(input);
            var dirs = fs.GetDirs().Where(dir => dir.Size <= 100000);
            var sum = dirs.Sum(dir => dir.Size);

            Console.WriteLine(sum);
        }

        private static void B(string[] input)
        {
            IFileSystem fs = FileSystem.SetUpFileSystem(input);
            var dirs = fs.GetDirs();
            var root = fs.GetRoot();
            long needed = 30000000 - (70000000 - root.Size);
            var smallest = dirs.Where(d => d.Size >= needed).Min(n => n.Size);

            Console.WriteLine(smallest);
        }
    }
}