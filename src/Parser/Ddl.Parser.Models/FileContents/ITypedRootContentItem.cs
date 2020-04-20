using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.FileContents
{
    public interface ITypedRootContentItem : IRootContentItem
    {
        ITypeName TypeName { get; }
    }
}
