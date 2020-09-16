using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IDdlContentUnitCollectionTypeResolver
    {
        Result<IReadOnlyList<ContentUnit>> ResolveCollection(
            IReadOnlyList<ContentUnit> contentUnits,
            TypeReferenceIndex typeReferenceIndex);
    }
}
