namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public abstract class RootItemBuildResult
    {
        protected RootItemBuildResult(RootItemBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootItemBuildResultKind.Success;

        public bool IsError => this.ResultKind != RootItemBuildResultKind.Success;

        public RootItemBuildResultKind ResultKind { get; }

        public static RootItemBuildError FromError(string errorMessage)
        {
            return new RootItemBuildError(errorMessage);
        }
    }
}
