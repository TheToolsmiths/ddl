using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Compilers.Wrappers
{
    internal class RootItemCompilerWrapper<TResolver, TItem> : RootItemCompilerWrapper
        where TResolver : IItemCompiler<TItem>
        where TItem : class, IRootItem
    {
        private readonly TResolver compiler;

        public RootItemCompilerWrapper(TResolver compiler)
        {
            this.compiler = compiler;
        }

        public override RootItemCompileResult CompileItem(IRootItemCompileContext context, IRootItem item)
        {
            return this.compiler.CompileItem(context, (TItem)item);
        }
    }

    internal abstract class RootItemCompilerWrapper
    {
        public abstract RootItemCompileResult CompileItem(IRootItemCompileContext context, IRootItem item);
    }
}
