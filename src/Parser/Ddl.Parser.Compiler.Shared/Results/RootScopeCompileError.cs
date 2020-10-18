namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootScopeCompileError : RootScopeCompileResult
    {
        public RootScopeCompileError(string errorMessage)
            : base(RootScopeCompileResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
