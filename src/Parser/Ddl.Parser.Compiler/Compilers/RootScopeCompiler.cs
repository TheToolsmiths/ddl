using System;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    internal class RootScopeCompiler : IRootScopeCompiler
    {
        private readonly RootItemCompilerResolver compilerResolver;

        public RootScopeCompiler(RootItemCompilerResolver compilerResolver)
        {
            this.compilerResolver = compilerResolver;
        }

        public RootScopeCompileResult ResolveScopeTypes(IRootScopeCompileContext context, IRootScope scope)
        {
            if (this.compilerResolver.TryResolveScopeCompiler(scope, out var compilerWrapper) == false)
            {
                throw new NotImplementedException();
            }

            return compilerWrapper.CompileScope(context, scope);
        }
    }
}
