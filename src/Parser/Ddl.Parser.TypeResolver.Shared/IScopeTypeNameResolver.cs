using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IScopeTypeNameResolver
    {
        QualifiedItemTypeNameResolution Resolve(TypedItemName itemName);

        QualifiedSubItemTypeNameResolution Resolve(TypedSubItemName subItemName);
    }
}
