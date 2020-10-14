using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Package.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IDdlContentUnitCollectionTypeResolver
    {
        Result<IReadOnlyList<ContentUnit>> ResolveCollection(
            IReadOnlyList<ContentUnit> contentUnits,
            PackageTypeIndex packageTypeIndex);
    }
}
