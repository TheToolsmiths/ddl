using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{

    public interface IItemCompiler<TItem> : IItemCompiler
        where TItem : class, IRootItem
    {
        public RootItemCompileResult CompileItem(IRootItemCompileContext itemContext, TItem item);
    }

    public interface IItemCompiler
    {
    }
}
