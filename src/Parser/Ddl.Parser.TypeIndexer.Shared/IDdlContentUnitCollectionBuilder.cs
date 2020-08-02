using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public interface IDdlContentUnitCollectionIndexer
    {
        Result<PackageIndexedTypes> IndexCollection(IEnumerable<ContentUnit> contentUnits);
    }
}
