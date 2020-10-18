using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface IContentUnitCompiler
    {
        Result<CompiledContentUnitScope> ResolveContentUnitScopeTypes(IRootScopeCompileContext context, ContentUnitScope rootScope);
    }
}
