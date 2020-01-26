using System;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser
{
    public class ParseResult<T>
        where T : class
    {
        private ParseResult(T value)
        {
            this.Value = value;
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }

        private ParseResult(string errorMessage)
        {
            this.Value = default;
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess { get; }

        public T? Value { get; }

        public static ParseResult<T> FromValue(T fileContents)
        {
            return new ParseResult<T>(fileContents);
        }

        public static ParseResult<T> FromException(Exception exception)
        {
            return new ParseResult<T>(exception.Message);
        }

        public static ParseResult<T> FromErrorMessage(string errorMessage)
        {
            return new ParseResult<T>(errorMessage: errorMessage);
        }
    }
}
