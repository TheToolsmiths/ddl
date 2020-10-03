using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public interface IDdlPackageIndexer
    {
        Result<PackageTypeIndex> IndexCollection(IReadOnlyList<ContentUnit> contentUnits);
    }
}
