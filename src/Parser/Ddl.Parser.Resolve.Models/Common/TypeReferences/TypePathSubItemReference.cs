using Ddl.Parser.Resolve.Models.Common.ItemReferences;

using TheToolsmiths.Ddl.Parser.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace Ddl.Parser.Resolve.Models.Common.TypeReferences
{
    public class TypePathSubItemReference : TypePathEntityReference
    {
        public TypePathSubItemReference(
            SubItemTypeName subItemTypeName,
            NamespacePath namespacePath,
            SubItemReference subItemReference)
        {
            this.SubItemTypeName = subItemTypeName;
            this.NamespacePath = namespacePath;
            this.SubItemReference = subItemReference;
        }

        public SubItemReference SubItemReference { get; }

        public SubItemTypeName SubItemTypeName { get; }

        public NamespacePath NamespacePath { get; }

        public override string ToString()
        {
            return $"{this.SubItemReference} > {this.NamespacePath}::{this.SubItemTypeName}";
        }
    }
}
