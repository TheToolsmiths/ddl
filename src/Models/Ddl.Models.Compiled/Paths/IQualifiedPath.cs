using System.Collections.Immutable;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Paths
{
    public interface IQualifiedPath<TPart>
        where TPart : IPathPart
    {
        bool IsRooted { get; }

        ImmutableArray<TPart> PathParts { get; }
    }
}
