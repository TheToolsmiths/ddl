using System;

namespace TheToolsmiths.Ddl.Parser.Errors
{
    public class ContentUnitParseError
    {
        private ContentUnitParseError(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public static ContentUnitParseError FromException(Exception exception)
        {
            return new ContentUnitParseError(exception.Message);
        }

        public static ContentUnitParseError FromErrorMessage(string errorMessage)
        {
            return new ContentUnitParseError(errorMessage);
        }

        public static ContentUnitParseError FromParseResult(ContentUnitParseResult result)
        {
            if (result.IsError == false)
            {
                throw new ArgumentException(nameof(result));
            }

            return new ContentUnitParseError(result.ErrorMessage);
        }
    }
}
