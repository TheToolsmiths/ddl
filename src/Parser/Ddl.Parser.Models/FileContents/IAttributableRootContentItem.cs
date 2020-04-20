using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Models.FileContents
{
    public interface IAttributableRootContentItem : IRootContentItem
    {
        IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
