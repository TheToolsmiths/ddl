using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public interface IAttributableRootItem : IRootItem
    {
        IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
