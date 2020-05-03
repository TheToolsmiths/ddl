using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    public interface ITypedRootContentItem : IRootContentItem, ITypedContentItem
    {
        ITypeName TypeName { get; }
    }
}
