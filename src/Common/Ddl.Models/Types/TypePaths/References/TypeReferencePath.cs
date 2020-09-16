using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public class TypeReferencePath
    {
        protected TypeReferencePath(bool isRooted, IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            this.IsRooted = isRooted;
            this.PathParts = new ReadOnlyMemory<TypeReferencePathPart>(pathParts.ToArray());
        }

        public ReadOnlyMemory<TypeReferencePathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static TypeReferencePath CreateFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return new TypeReferencePath(false, pathParts);
        }

        public static RootTypeReferencePath CreateRootedFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return RootTypeReferencePath.CreateFromParts(pathParts);
        }

        public override string ToString()
        {
            return $"{(this.IsRooted ? "::" : "")}{string.Join("::", this.PathParts.ToArray().Select(pp => pp.ToString()))}";
        }
    }
}
