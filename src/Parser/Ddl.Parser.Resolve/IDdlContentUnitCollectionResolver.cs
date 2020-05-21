using System.Collections.Generic;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Resolve
{
    public interface IDdlContentUnitCollectionResolver
    {
        Result ResolveContentUnits(IEnumerable<ContentUnit> contentUnits);
    }
}
