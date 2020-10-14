namespace TheToolsmiths.Ddl.Models.Compiled.Paths
{
    public interface IPathPart
    {
        public PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
