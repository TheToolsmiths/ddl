using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{

    public interface IScopeCompiler<TScope> : IScopeCompiler
        where TScope : class, IRootScope
    {
        public RootScopeCompileResult ResolveScopeTypes(IRootScopeCompileContext scopeContext, TScope scope);
    }

    public interface IScopeCompiler
    {
    }
}
