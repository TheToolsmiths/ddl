using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public interface IAttributableRootContentItem : IRootContentItem
    {
        IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
