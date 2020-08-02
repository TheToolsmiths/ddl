namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Results
{
    public abstract class RootItemIndexResult
    {
        protected RootItemIndexResult(RootItemIndexResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootItemIndexResultKind.Success;

        public bool IsError => this.ResultKind != RootItemIndexResultKind.Success;

        public RootItemIndexResultKind ResultKind { get; }

        public static RootItemIndexError FromError(string errorMessage)
        {
            return new RootItemIndexError(errorMessage);
        }
    }
}
