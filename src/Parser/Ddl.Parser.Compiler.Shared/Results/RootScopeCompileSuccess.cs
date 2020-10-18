using TheToolsmiths.Ddl.Models.Compiled.Scopes;

namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootScopeCompileSuccess : RootScopeCompileResult
    {
        public RootScopeCompileSuccess(ICompiledScope compiledScope)
            : base(RootScopeCompileResultKind.Success)
        {
            this.CompiledScope = compiledScope;
        }

        public ICompiledScope CompiledScope { get; }
    }
}
