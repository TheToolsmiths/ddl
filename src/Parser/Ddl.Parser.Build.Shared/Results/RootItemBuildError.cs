namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootItemBuildError : RootItemBuildResult
    {
        public RootItemBuildError(string errorMessage)
            : base(RootItemBuildResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}