using Ddl.Parser.Resolve.Models.Common.ItemReferences;

using TheToolsmiths.Ddl.Parser.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace Ddl.Parser.Resolve.Models.Common.TypeReferences
{
    public class TypePathItemReference : TypePathEntityReference
    {
        public TypePathItemReference(ItemTypeName itemTypeName, NamespacePath namespacePath, ItemReference itemReference)
        {
            this.ItemTypeName = itemTypeName;
            this.NamespacePath = namespacePath;
            this.ItemReference = itemReference;
        }

        public ItemTypeName ItemTypeName { get; }

        public NamespacePath NamespacePath { get; }

        public ItemReference ItemReference { get; }

        public override string ToString()
        {
            return $"{this.ItemReference} > {this.NamespacePath}::{this.ItemTypeName}";
        }
    }
}
