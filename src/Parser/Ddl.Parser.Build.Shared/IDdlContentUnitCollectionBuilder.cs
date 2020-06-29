using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IDdlContentUnitCollectionBuilder
    {
        Result BuildCollection(IEnumerable<AstContentUnit> contentUnits);
    }
}
