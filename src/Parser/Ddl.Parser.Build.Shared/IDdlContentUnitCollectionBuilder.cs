using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IDdlContentUnitCollectionBuilder
    {
        Result BuildCollection(IEnumerable<AstContentUnit> contentUnits);
    }
}
