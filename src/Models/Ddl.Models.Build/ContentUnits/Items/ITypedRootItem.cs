using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Items
{
    public interface ITypedRootItem : IRootItem
    {
        TypedItemName TypeName { get; }

        QualifiedItemTypeNameResolution TypeNameResolution { get; }
    }
}
