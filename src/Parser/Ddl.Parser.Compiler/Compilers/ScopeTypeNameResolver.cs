using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    public class ScopeTypeNameResolver : IScopeTypeNameResolver
    {
        public ScopeTypeNameResolver(QualifiedNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;
        }

        public QualifiedNamespacePath NamespacePath { get; }

        public QualifiedItemTypeName Resolve(ItemTypeName itemName)
        {
            var typeName = new QualifiedItemTypeName(itemName, this.NamespacePath);

            return typeName;
        }

        public QualifiedSubItemTypeName Resolve(SubItemTypeName subItemName)
        {
            var typeName = new QualifiedSubItemTypeName(subItemName, this.NamespacePath);

            return typeName;
        }
    }
}
