using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface IDdlContentUnitCollectionCompiler
    {
        Result<IReadOnlyList<CompiledContentUnit>> CompileCollection(
            IReadOnlyList<ContentUnit> contentUnits,
            ContentUnitsTypeIndex packageTypeIndex);
    }
}
