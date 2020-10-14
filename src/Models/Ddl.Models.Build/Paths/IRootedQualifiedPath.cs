namespace TheToolsmiths.Ddl.Models.Build.Paths
{
    public interface IRootedQualifiedPath<TPart> : IQualifiedPath<TPart>
        where TPart : IPathPart
    {
        bool IQualifiedPath<TPart>.IsRooted => true;
    }
}
