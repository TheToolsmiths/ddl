namespace TheToolsmiths.Ddl.Models.Build.Paths
{
    public interface IPathPart
    {
        public PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
