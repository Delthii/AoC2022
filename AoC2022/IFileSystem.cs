namespace AoC2022
{
    public interface IFileSystem
    {
        List<FileNode> GetDirs();
        List<FileNode> GetFiles();
        FileNode GetRoot();
    }
}