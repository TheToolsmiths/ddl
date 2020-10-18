using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Build.Types.Paths
{
    public class RootTypePath : TypePath
    {
        private RootTypePath(IReadOnlyList<TypePathPart> pathParts)
            : base(true, pathParts)
        {
        }

        public new static RootTypePath CreateFromParts(IReadOnlyList<TypePathPart> pathParts)
        {
            return new RootTypePath(pathParts);
        }
    }
}
