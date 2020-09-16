namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootScopeTypeResolveResult
    {
        protected RootScopeTypeResolveResult(RootScopeTypeResolveResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootScopeTypeResolveResultKind.Success;

        public bool IsError => this.ResultKind != RootScopeTypeResolveResultKind.Success;

        public RootScopeTypeResolveResultKind ResultKind { get; }

        public static RootScopeTypeResolveError FromError(string errorMessage)
        {
            return new RootScopeTypeResolveError(errorMessage);
        }
    }
}
