using TheToolsmiths.Ddl.Models.Compiled.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items
{
    public interface ITypedSubItem : ISubItem
    {
        QualifiedSubItemTypeNameResolution TypeNameResolution { get; }
    }
}
