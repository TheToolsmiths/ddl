using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public interface ITypedRootItem : IRootItem, ITypedContentItem
    {
        ITypeName TypeName { get; }
    }
}
