using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface IRootScopeCompiler
    {
        RootScopeCompileResult ResolveScopeTypes(IRootScopeCompileContext context, IRootScope scope);
    }
}
