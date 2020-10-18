using System;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers
{
    internal class RootItemCompiler : IRootItemCompiler
    {
        private readonly RootItemCompilerResolver compilerResolver;

        public RootItemCompiler(RootItemCompilerResolver compilerResolver)
        {
            this.compilerResolver = compilerResolver;
        }

        public RootItemCompileResult CompileItem(IRootItemCompileContext context, IRootItem item)
        {
            if (this.compilerResolver.TryResolveItemCompiler(item, out var compilerWrapper) == false)
            {
                throw new NotImplementedException();
            }

            return compilerWrapper.CompileItem(context, item);
        }
    }
}
