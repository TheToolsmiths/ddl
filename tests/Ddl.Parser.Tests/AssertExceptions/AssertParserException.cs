using System;

namespace TheToolsmiths.Ddl.Parser.Tests.AssertExceptions
{
    public class AssertParserException : Exception
    {
        public AssertParserException(string message)
            : base(message)
        {
        }
    }
}
