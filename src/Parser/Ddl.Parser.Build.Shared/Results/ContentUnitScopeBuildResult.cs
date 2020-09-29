namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public abstract class ContentUnitScopeBuildResult
    {
        protected ContentUnitScopeBuildResult(ContentUnitScopeBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
        }

        public bool IsSuccess => this.ResultKind == ContentUnitScopeBuildResultKind.Success;

        public bool IsError => this.ResultKind != ContentUnitScopeBuildResultKind.Success;

        public ContentUnitScopeBuildResultKind ResultKind { get; }

        public static ContentUnitScopeBuildError FromError(string errorMessage)
        {
            return new ContentUnitScopeBuildError(errorMessage);
        }
    }
}