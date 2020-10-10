using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Package.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    public interface IDdlContentUnitCollectionPackager
    {
        Result<Package> PackageCollection(IReadOnlyList<ContentUnit> contentUnits, PackageTypeIndex packageTypeIndex);
    }
}
