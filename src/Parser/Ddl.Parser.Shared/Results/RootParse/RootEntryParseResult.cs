using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser
{
    public abstract class RootEntryParseResult
    {
        protected RootEntryParseResult(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }

        public bool IsError => this.IsSuccess == false;

        public static ParserNotFoundRootEntryParseError CreateParserHandlerNotFound(
            IReadOnlyList<string> parserLookupIdentifiers)
        {
            return new ParserNotFoundRootEntryParseError(parserLookupIdentifiers);
        }
    }

    public abstract class RootEntryParseError : RootEntryParseResult
    {
        internal RootEntryParseError(string errorMessage)
            : base(isSuccess: false)
        {
            this.ErrorMessage = errorMessage;
        }

        protected RootEntryParseError()
            : base(isSuccess: false)
        {
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }
    }

    public interface IParserNotFoundParseError
    {
        IReadOnlyList<string> ParserLookupIdentifiers { get; }
    }

    public class ParserNotFoundRootEntryParseError : RootEntryParseError, IParserNotFoundParseError
    {
        internal ParserNotFoundRootEntryParseError(string errorMessage, IReadOnlyList<string> parserLookupIdentifiers)
            : base(errorMessage)
        {
            this.ParserLookupIdentifiers = parserLookupIdentifiers;
        }

        internal ParserNotFoundRootEntryParseError(IReadOnlyList<string> parserLookupIdentifiers)
        {
            this.ParserLookupIdentifiers = parserLookupIdentifiers;
        }

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }
    }
}
