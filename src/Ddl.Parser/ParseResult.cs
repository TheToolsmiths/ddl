using System;

namespace TheToolsmiths.Ddl.Parser
{
    public static class ParseResult
    {
        public static ParseResult<T> FromValue<T>(T fileContents)
            where T : class
        {
            return new ParseResult<T>(fileContents);
        }

        public static ParseResult<T> FromException<T>(Exception exception)
            where T : class
        {
            return new ParseResult<T>(exception.Message);
        }

        public static ParseResult<T> FromErrorMessage<T>(string errorMessage)
            where T : class
        {
            return new ParseResult<T>(errorMessage: errorMessage);
        }
    }
}
