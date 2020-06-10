using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser
{
    public class ContentUnitParseResult
    {
        private ContentUnitParseResult(AstContentUnit astContent)
        {
            this.AstContent = astContent;
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }

        private ContentUnitParseResult(string errorMessage)
        {
            this.AstContent = default!;
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess { get; }

        public bool IsError => this.IsSuccess == false;

        public AstContentUnit AstContent { get; }

        public static ContentUnitParseResult FromValue(AstContentUnit astContentUnit)
        {
            return new ContentUnitParseResult(astContentUnit);
        }

        public static ContentUnitParseResult FromException(Exception exception)
        {
            return new ContentUnitParseResult(exception.Message);
        }

        public static ContentUnitParseResult FromErrorMessage(string errorMessage)
        {
            return new ContentUnitParseResult(errorMessage);
        }
    }
}
