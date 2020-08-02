namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Results
{
    public class RootItemIndexError : RootItemIndexResult
    {
        public RootItemIndexError(string errorMessage)
            : base(RootItemIndexResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
