using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface ICommonBuilders
    {
        Result<ValueInitialization> BuildValueInitialization(Ast.Models.Values.ValueInitialization valueInitialization);

        Result<IReadOnlyList<IAttributeUse>> BuildAttributes(
            IReadOnlyList<Ast.Models.AttributeUsage.IAstAttributeUse> attributes);
    }
}
