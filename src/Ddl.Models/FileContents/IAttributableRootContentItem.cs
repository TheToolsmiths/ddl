using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.FileContents
{
    public interface IAttributableRootContentItem : IRootContentItem
    {
        IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
