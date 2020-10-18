using System.Collections.Immutable;

namespace TheToolsmiths.Ddl.Models.Paths
{
    public interface IPath<TPart>
        where TPart : IPathPart
    {
        bool IsRooted { get; }

        ImmutableArray<TPart> PathParts { get; }
    }
}
