using TheToolsmiths.Ddl.Models.Compiled.Items;

namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootItemCompileSuccess : RootItemCompileResult
    {
        public RootItemCompileSuccess(ICompiledItem compiledItem)
            : base(RootItemCompileResultKind.Success)
        {
            this.CompiledItem = compiledItem;
        }

        public ICompiledItem CompiledItem { get; }
    }
}
