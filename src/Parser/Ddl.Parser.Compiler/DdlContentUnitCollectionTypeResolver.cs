using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    internal class DdlContentUnitCollectionCompiler : IDdlContentUnitCollectionCompiler
    {
        private readonly DdlContentUnitCompiler compiler;

        public DdlContentUnitCollectionCompiler(DdlContentUnitCompiler compiler)
        {
            this.compiler = compiler;
        }

        public Result<IReadOnlyList<CompiledContentUnit>> CompileCollection(
            IReadOnlyList<ContentUnit> contentUnits,
            ContentUnitsTypeIndex packageTypeIndex)
        {
            var indexedContentUnits = new List<CompiledContentUnit>();

            foreach (var contentUnit in contentUnits)
            {
                var result = this.compiler.Compile(contentUnit, packageTypeIndex);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                indexedContentUnits.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<CompiledContentUnit>>(indexedContentUnits);
        }

        public Result<CompiledContentUnit> CompileContentUnit(ContentUnit contentUnit, ContentUnitsTypeIndex packageTypeIndex)
        {
            return this.compiler.Compile(contentUnit, packageTypeIndex);
        }
    }
}
