using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface IScopeTypeNameResolver
    {
        QualifiedItemTypeName Resolve(ItemTypeName itemName);

        QualifiedSubItemTypeName Resolve(SubItemTypeName subItemName);
    }
}
