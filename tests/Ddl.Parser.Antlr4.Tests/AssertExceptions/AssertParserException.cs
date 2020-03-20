using System;

namespace TheToolsmiths.Ddl.Parser.Tests.AssertExceptions
{
    public class AssertParserException : Exception
    {
        public AssertParserException()
        {
        }

        public AssertParserException(string message)
            : base(message)
        {
        }

        public AssertParserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
