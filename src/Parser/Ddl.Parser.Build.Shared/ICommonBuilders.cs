using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface ICommonBuilders
    {
        Result<ValueInitialization> BuildValueInitialization(Ast.Models.Values.ValueInitialization valueInitialization);

        Result<IReadOnlyList<IAttributeUse>> BuildAttributes(
            IReadOnlyList<Ast.Models.AttributeUsage.IAstAttributeUse> attributes);
    }
}
