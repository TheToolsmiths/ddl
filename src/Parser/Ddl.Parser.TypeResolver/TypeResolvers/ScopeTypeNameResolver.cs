using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    public class ScopeTypeNameResolver : IScopeTypeNameResolver
    {
        public ScopeTypeNameResolver(RootNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;
        }

        public RootNamespacePath NamespacePath { get; }

        public QualifiedItemTypeNameResolution Resolve(TypedItemName itemName)
        {
            var typeName = new QualifiedItemTypeName(itemName, this.NamespacePath);

            return new ResolvedQualifiedItemTypeName(typeName);
        }

        public QualifiedSubItemTypeNameResolution Resolve(TypedSubItemName subItemName)
        {
            var typeName = new QualifiedSubItemTypeName(subItemName, this.NamespacePath);

            return new ResolvedQualifiedSubItemTypeName(typeName);
        }
    }
}
