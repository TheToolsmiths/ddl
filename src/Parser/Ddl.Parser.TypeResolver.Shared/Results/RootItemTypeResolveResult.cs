namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public abstract class RootItemTypeResolveResult
    {
        protected RootItemTypeResolveResult(RootItemTypeResolveResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootItemTypeResolveResultKind.Success;

        public bool IsError => this.ResultKind != RootItemTypeResolveResultKind.Success;

        public RootItemTypeResolveResultKind ResultKind { get; }

        public static RootItemTypeResolveError FromError(string errorMessage)
        {
            return new RootItemTypeResolveError(errorMessage);
        }
    }
}
