namespace TheToolsmiths.Ddl.Models.Paths
{
    public interface IPathPart
    {
        public PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
