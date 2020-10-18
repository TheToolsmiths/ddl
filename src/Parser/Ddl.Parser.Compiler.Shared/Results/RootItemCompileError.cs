namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootItemCompileError : RootItemCompileResult
    {
        public RootItemCompileError(string errorMessage)
            : base(RootItemCompileResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
