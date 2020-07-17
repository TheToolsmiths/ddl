namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootScopeBuildError : RootScopeBuildResult
    {
        public RootScopeBuildError(string errorMessage)
            : base(RootScopeBuildResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}