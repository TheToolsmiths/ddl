using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser
{
    public class ContentUnitParseResult
    {
        private ContentUnitParseResult(ContentUnit content)
        {
            this.Content = content;
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }

        private ContentUnitParseResult(string errorMessage)
        {
            this.Content = default!;
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess { get; }

        public bool IsError => this.IsSuccess == false;

        public ContentUnit Content { get; }

        public static ContentUnitParseResult FromValue(ContentUnit contentUnit)
        {
            return new ContentUnitParseResult(contentUnit);
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
