using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public interface ITypedRootContentItem : IRootContentItem, ITypedContentItem
    {
        ITypeName TypeName { get; }
    }
}
