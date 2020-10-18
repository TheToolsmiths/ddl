using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface IRootItemCompiler
    {
        RootItemCompileResult CompileItem(IRootItemCompileContext context, IRootItem item);
    }
}
