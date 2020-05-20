using System.Collections.Generic;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Resolve
{
    public interface IDdlContentUnitCollectionResolver
    {
        Result ResolveContentUnits(IReadOnlyList<ContentUnit> contentUnits);
    }
}
