using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Package;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    public interface IDdlContentUnitCollectionPackager
    {
        Result<Package> PackageCollection(
            IReadOnlyList<CompiledContentUnit> contentUnits,
            ContentUnitsTypeIndex contentUnitsTypeIndex);
    }
}
