namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootItemTypeResolveError : RootItemTypeResolveResult
    {
        public RootItemTypeResolveError(string errorMessage)
            : base(RootItemTypeResolveResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
