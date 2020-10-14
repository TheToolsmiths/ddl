using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.References
{
    public class RootTypeReferencePath : TypeReferencePath
    {
        private RootTypeReferencePath(IReadOnlyList<TypeReferencePathPart> pathParts)
            : base(true, pathParts)
        {
        }

        public new static RootTypeReferencePath CreateFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return new RootTypeReferencePath(pathParts);
        }
    }
}
