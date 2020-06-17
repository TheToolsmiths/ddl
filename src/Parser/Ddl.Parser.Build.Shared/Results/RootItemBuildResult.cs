namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootItemBuildSuccess : RootItemBuildResult
    {
        public RootItemBuildSuccess()
            : base(RootItemBuildResultKind.Success)
        {
        }
    }

    public class RootItemBuildError : RootItemBuildResult
    {
        public RootItemBuildError(string errorMessage)
            : base(RootItemBuildResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }

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
    public enum RootItemBuildResultKind
    {
        Success,
        Error
    }
}
