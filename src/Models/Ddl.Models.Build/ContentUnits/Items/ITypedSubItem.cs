using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Items
{
    public interface ITypedSubItem : ISubItem
    {
        QualifiedSubItemTypeNameResolution TypeNameResolution { get; }
    }
}
