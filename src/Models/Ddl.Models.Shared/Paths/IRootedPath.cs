namespace TheToolsmiths.Ddl.Models.Paths
{
    public interface IRootedPath<TPart> : IPath<TPart>
        where TPart : IPathPart
    {
        bool IPath<TPart>.IsRooted => true;
    }
}
