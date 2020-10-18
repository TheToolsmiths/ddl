namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public abstract class RootItemCompileResult
    {
        protected RootItemCompileResult(RootItemCompileResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootItemCompileResultKind.Success;

        public bool IsError => this.ResultKind != RootItemCompileResultKind.Success;

        public RootItemCompileResultKind ResultKind { get; }

        public static RootItemCompileError FromError(string errorMessage)
        {
            return new RootItemCompileError(errorMessage);
        }
    }
}
