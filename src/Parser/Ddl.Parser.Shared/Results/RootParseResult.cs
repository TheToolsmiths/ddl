using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser
{
    public class RootParseResult
    {
        protected RootParseResult(RootParseResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = string.Empty;
        }

        protected RootParseResult(string errorMessage, RootParseResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = errorMessage;
        }

        protected RootParseResult(IEnumerable<string> parserLookupIdentifiers, RootParseResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = parserLookupIdentifiers.ToList();
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess => this.ResultKind == RootParseResultKind.Success;

        public bool IsError => this.ResultKind != RootParseResultKind.Success;

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }

        public RootParseResultKind ResultKind { get; }

        public static RootParseResult CreateParserHandlerNotFound(IEnumerable<string> parserLookupIdentifiers)
        {
            return new RootParseResult(parserLookupIdentifiers, RootParseResultKind.ParserHandlerNotFound);
        }

        public static RootParseResult FromError(string errorMessage)
        {
            return new RootParseResult(errorMessage, RootParseResultKind.Error);
        }

        public static RootParseResult<T> CreateParserHandlerNotFound<T>(IEnumerable<string> parserLookupIdentifiers)
            where T : class, IRootEntry
        {
            return new RootParseResult<T>(default!, parserLookupIdentifiers, RootParseResultKind.ParserHandlerNotFound);
        }

        public static RootParseResult<T> FromResult<T>(T value)
            where T : class, IRootEntry
        {
            return new RootParseResult<T>(value, RootParseResultKind.Success);
        }

        public static RootParseResult<T> FromError<T>(string errorMessage)
            where T : class, IRootEntry
        {
            return new RootParseResult<T>(errorMessage, RootParseResultKind.Error);
        }
    }
}
