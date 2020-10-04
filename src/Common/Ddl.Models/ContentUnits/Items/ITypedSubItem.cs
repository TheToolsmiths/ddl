using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items
{
    public interface ITypedSubItem : ISubItem
    {
        QualifiedSubItemTypeNameResolution TypeNameResolution { get; }
    }
}
