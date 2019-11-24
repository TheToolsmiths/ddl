namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FileScope
    {
        public FileScope(FileContents contents)
        {
            Contents = contents;
        }

        public FileContents Contents { get; }
    }
}
