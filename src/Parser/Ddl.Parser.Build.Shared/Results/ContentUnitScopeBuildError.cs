namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class ContentUnitScopeBuildError : ContentUnitScopeBuildResult
    {
        public ContentUnitScopeBuildError(string errorMessage)
            : base(ContentUnitScopeBuildResultKind.Error)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}