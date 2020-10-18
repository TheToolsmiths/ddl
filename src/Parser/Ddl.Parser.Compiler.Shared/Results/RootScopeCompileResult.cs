namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootScopeCompileResult
    {
        protected RootScopeCompileResult(RootScopeCompileResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootScopeCompileResultKind.Success;

        public bool IsError => this.ResultKind != RootScopeCompileResultKind.Success;

        public RootScopeCompileResultKind ResultKind { get; }

        public static RootScopeCompileError FromError(string errorMessage)
        {
            return new RootScopeCompileError(errorMessage);
        }
    }
}
