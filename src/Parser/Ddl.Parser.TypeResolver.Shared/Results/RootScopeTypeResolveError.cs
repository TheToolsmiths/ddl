namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootScopeTypeResolveError : RootScopeTypeResolveResult
    {
        public RootScopeTypeResolveError(string errorMessage)
            : base(RootScopeTypeResolveResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
