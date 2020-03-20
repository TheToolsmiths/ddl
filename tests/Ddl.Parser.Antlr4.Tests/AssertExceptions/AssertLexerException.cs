using System;

namespace TheToolsmiths.Ddl.Parser.Tests.AssertExceptions
{
    public class AssertLexerException : Exception
    {
        public AssertLexerException()
        {
        }

        public AssertLexerException(string message)
            : base(message)
        {
        }

        public AssertLexerException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
