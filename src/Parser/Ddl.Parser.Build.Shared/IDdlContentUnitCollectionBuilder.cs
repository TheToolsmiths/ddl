using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IDdlContentUnitCollectionBuilder
    {
        Result<IReadOnlyList<ContentUnit>> BuildCollection(IEnumerable<AstContentUnit> astContentUnits);
    }
}
