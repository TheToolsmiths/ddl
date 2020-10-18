using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Paths
{
    public interface IRootedQualifiedPath<TPart> : IQualifiedPath<TPart>
        where TPart : IPathPart
    {
        bool IQualifiedPath<TPart>.IsRooted => true;
    }
}
