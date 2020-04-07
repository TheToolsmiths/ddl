using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IRootItemParserContext : IParserContext
    {
        IReadOnlyList<IAttributeUse> AttributeList { get; }

        IRootParserContext RootParserContext { get; }
    }
}
