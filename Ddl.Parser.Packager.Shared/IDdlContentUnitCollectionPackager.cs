using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    public interface IDdlContentUnitCollectionPackager
    {
        Result<object> ResolveCollection(IReadOnlyList<ContentUnit> contentUnits, PackageTypeIndex packageTypeIndex);
    }
}
