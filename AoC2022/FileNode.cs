namespace AoC2022
{
    public class FileNode
    {
        public FileNode? Parent { get; set; }
        public List<FileNode> Children = new List<FileNode>();
        public required NodeType Type { get; init; }
        public required string Name { get;  init; }
        public long Size { get; set; } = 0;

        public override string ToString()
        {
            var typ = Type == NodeType.File ? "file" : "dir";
            return $"{typ} {Name}";
        }
    }
}