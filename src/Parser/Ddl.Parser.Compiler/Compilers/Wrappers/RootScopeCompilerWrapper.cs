using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers.Wrappers
{
    internal class RootScopeCompilerWrapper<TResolver, TScope> : RootScopeCompilerWrapper
        where TResolver : IScopeCompiler<TScope>
        where TScope : class, IRootScope
    {
        private readonly TResolver compiler;

        public RootScopeCompilerWrapper(TResolver compiler)
        {
            this.compiler = compiler;
        }

        public override RootScopeCompileResult CompileScope(IRootScopeCompileContext context, IRootScope item)
        {
            return this.compiler.ResolveScopeTypes(context, (TScope)item);
        }
    }

    internal abstract class RootScopeCompilerWrapper
    {
        public abstract RootScopeCompileResult CompileScope(IRootScopeCompileContext context, IRootScope item);
    }
}
