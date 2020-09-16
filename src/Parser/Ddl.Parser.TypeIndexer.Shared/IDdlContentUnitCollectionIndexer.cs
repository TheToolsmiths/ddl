using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public interface IDdlContentUnitCollectionIndexer
    {
        Result<TypeReferenceIndex> IndexCollection(IEnumerable<ContentUnit> contentUnits);
    }
}
