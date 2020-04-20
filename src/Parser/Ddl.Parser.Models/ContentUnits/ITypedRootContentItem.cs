using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    public interface ITypedRootContentItem : IRootContentItem
    {
        ITypeName TypeName { get; }
    }
}
