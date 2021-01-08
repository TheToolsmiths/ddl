using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public interface IDdlPackageIndexer
    {
        Result<ContentUnitsTypeIndex> IndexCollection(IReadOnlyList<ContentUnit> contentUnits);

        Result<ContentUnitsTypeIndex> IndexContentUnit(ContentUnit contentUnit);
    }
}
