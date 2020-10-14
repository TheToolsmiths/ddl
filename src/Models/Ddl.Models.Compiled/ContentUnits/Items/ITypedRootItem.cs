using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items
{
    public interface ITypedRootItem : IRootItem
    {
        TypedItemName TypeName { get; }

        QualifiedItemTypeNameResolution TypeNameResolution { get; }
    }
}
