namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public abstract class RootScopeBuildResult
    {
        protected RootScopeBuildResult(RootScopeBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootScopeBuildResultKind.Success;

        public bool IsError => this.ResultKind != RootScopeBuildResultKind.Success;

        public RootScopeBuildResultKind ResultKind { get; }

        public static RootScopeBuildError FromError(string errorMessage)
        {
            return new RootScopeBuildError(errorMessage);
        }
    }
}
