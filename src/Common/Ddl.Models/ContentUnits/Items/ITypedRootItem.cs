using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items
{
    public interface ITypedRootItem : IRootItem
    {
        TypedItemName TypeName { get; }

        QualifiedItemTypeNameResolution TypeNameResolution { get; }
    }
}
