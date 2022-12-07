namespace AoC2022
{
    public class FileSystem : IFileSystem
    {
        private List<FileNode> nodes = new();
        private FileNode Current;

        public FileSystem()
        {
            var rootroot = new FileNode
            {
                Name = "",
                Type = NodeType.Directory
            };

            Current = rootroot;
            InsertDir("/");
        }

        public static IFileSystem SetUpFileSystem(string[] input)
        {
            var fs = new FileSystem();
            for (int i = 0; i < input.Length; i++)
            {
                string row = input[i];
                var split = row.Split(' ');
                if (split[0] == "$")
                {
                    if (split[1] == "cd")
                    {
                        fs.ChangeDir(split);
                    }
                    else if (split[1] == "ls")
                    {
                        var listedNodes = input.Skip(i + 1).TakeWhile(r => !r.StartsWith("$")).ToArray();
                        i += listedNodes.Length;
                        foreach (var r in listedNodes)
                        {
                            fs.InsertNode(r.Split(' '));
                        }
                    }
                }
            }

            fs.CalcSizes();

            return fs;
        }

        public List<FileNode> GetDirs()
        {
            return nodes.Where(n => n.Type == NodeType.Directory).ToList();
        }

        public List<FileNode> GetFiles()
        {
            return nodes.Where(n => n.Type == NodeType.File).ToList();
        }

        public FileNode GetRoot()
        {
            return nodes.Single(n => n.Name == "/");
        }

        private void InsertNode(string[] split)
        {
            if (split[0] == "dir")
            {
                InsertDir(split[1]);
            }
            else if (int.TryParse(split[0], out var size))
            {
                InsertFile(split[1], size);
            }
        }

        private void ChangeDir(string[] split)
        {
            if (split[2] == "..")
            {
                MoveUp();
            }
            else
            {
                MoveTo(split[2]);
            }
        }

        private void InsertNode(FileNode node)
        {
            nodes.Add(node);
        }

        private void InsertFile(string name, int size)
        {
            var node = new FileNode
            {
                Parent = Current,
                Name = name,
                Size = size,
                Type = NodeType.File,
            };

            if (!Current.Children.Any(n => n.Name == name))
            {
                Current.Children.Add(node);
            }

            InsertNode(node);
        }

        private void InsertDir(string name)
        {
            var node = new FileNode
            {
                Parent = Current,
                Name = name,
                Type = NodeType.Directory,
            };

            if (!Current.Children.Any(n => n.Name == name))
            {
                Current.Children.Add(node);
            }

            InsertNode(node);
        }

        private void MoveUp()
        {
            if (Current.Parent == null)
            {
                throw new NullReferenceException("Parent is null");
            }

            Current = Current.Parent;
        }

        private void MoveTo(string name)
        {
            Current = Current.Children.Single(n => n.Name == name);
        }

        private long CalcSizes()
        {
            return Rec(GetDirs().Single(n => n.Name == "/"));
        }

        private long Rec(FileNode node)
        {
            if (node.Type == NodeType.File)
            {
                return node.Size;
            }

            var tot = node.Children.Sum(c => Rec(c));
            node.Size = tot;
            return tot;
        }
    }
}