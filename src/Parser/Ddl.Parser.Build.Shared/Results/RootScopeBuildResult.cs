namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootScopeBuildSuccess : RootScopeBuildResult
    {
        public RootScopeBuildSuccess()
            : base(RootScopeBuildResultKind.Success)
        {
        }
    }

    public class RootScopeBuildError : RootScopeBuildResult
    {
        public RootScopeBuildError(string errorMessage)
            : base(RootScopeBuildResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }

    public class RootScopeBuildResult
    {
        protected RootScopeBuildResult(RootScopeBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == RootScopeBuildResultKind.Success;

        public bool IsError => this.ResultKind != RootScopeBuildResultKind.Success;

        public RootScopeBuildResultKind ResultKind { get; }

        public static RootItemBuildError FromError(string errorMessage)
        {
            return new RootItemBuildError(errorMessage);
        }
    }

    public enum RootScopeBuildResultKind
    {
        Success,
        Error
    }
}
