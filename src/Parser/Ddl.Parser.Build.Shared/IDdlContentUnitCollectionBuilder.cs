using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IDdlContentUnitCollectionBuilder
    {
        Result<IReadOnlyList<ContentUnit>> BuildCollection(IEnumerable<AstContentUnit> astContentUnits);
    }
}
