using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.FileContents
{
    public interface ITypedRootContentItem : IRootContentItem
    {
        ITypeName TypeName { get; }
    }
}
