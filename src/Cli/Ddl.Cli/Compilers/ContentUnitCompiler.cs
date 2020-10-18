using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Parser.Compiler;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.Compilers
{
    public class ContentUnitCompiler
    {
        private readonly ILogger<ContentUnitCompiler> log;
        private readonly IDdlContentUnitCollectionCompiler compiler;

        public ContentUnitCompiler(
            ILogger<ContentUnitCompiler> log,
            IDdlContentUnitCollectionCompiler compiler)
        {
            this.log = log;
            this.compiler = compiler;
        }

        public Result<IReadOnlyList<CompiledContentUnit>> CompileContentUnits(
            IReadOnlyList<ContentUnit> contentUnits,
            ContentUnitsTypeIndex contentUnitsTypeIndex)
        {
            using var _ = this.log.BeginScope("Compiling Content Units Types");

            var result = this.compiler.CompileCollection(contentUnits, contentUnitsTypeIndex);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            this.log.LogInformation("Content Units types compiled");

            return result;
        }
    }
}
