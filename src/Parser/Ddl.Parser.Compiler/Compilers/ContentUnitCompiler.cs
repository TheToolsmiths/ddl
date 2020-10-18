using System;

using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    internal class ContentUnitCompiler : IContentUnitCompiler
    {
        public Result<CompiledContentUnitScope> ResolveContentUnitScopeTypes(
            IRootScopeCompileContext context,
            ContentUnitScope rootScope)
        {
            var result = context.CommonCompilers.CompileScopeContent(rootScope.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var scopeContent = result.Value;

            var scope = new CompiledContentUnitScope(scopeContent);

            return Result.FromValue(scope);
        }
    }
}
