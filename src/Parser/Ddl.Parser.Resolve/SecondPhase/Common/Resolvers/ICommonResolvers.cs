using System.Collections.Generic;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.Common.Resolvers
{
    public interface ICommonResolvers
    {
        Result<Parser.Models.Values.ValueInitialization> ResolveValueInitialization(Parser.Ast.Models.Values.ValueInitialization astInitialization);

        Result<IReadOnlyList<IAttributeUse>> ResolveAttributes(IReadOnlyList<Parser.Ast.Models.AttributeUsage.IAttributeUse> astAttributes);
    }
}
