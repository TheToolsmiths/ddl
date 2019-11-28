using System;

namespace TheToolsmiths.Ddl.Parser.Tests.AssertExceptions
{
    public class AssertLexerException : Exception
    {
        public AssertLexerException(string message)
            : base(message)
        {
        }
    }
}
