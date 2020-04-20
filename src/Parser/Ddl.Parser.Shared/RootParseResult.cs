using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Shared
{
    public class RootParseResult<T>
        where T : IRootContentItem
    {
        private RootParseResult(T value, RootParseResultKind resultKind)
        {
            this.Value = value;
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = string.Empty;
        }

        private RootParseResult(string errorMessage, RootParseResultKind resultKind)
        {
            this.Value = default!;
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = errorMessage;
        }

        private RootParseResult(T value, IEnumerable<string> parserLookupIdentifiers, RootParseResultKind resultKind)
        {
            this.Value = value;
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = parserLookupIdentifiers.ToList();
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess => this.ResultKind == RootParseResultKind.Success;

        public bool IsError => this.ResultKind != RootParseResultKind.Success;

        public T Value { get; }

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }

        public RootParseResultKind ResultKind { get; }

        public static RootParseResult<IRootContentItem> CreateParserHandlerNotFound(IEnumerable<string> parserLookupIdentifiers)
        {
            return new RootParseResult<IRootContentItem>(default!, parserLookupIdentifiers, RootParseResultKind.ParserHandlerNotFound);
        }

        public static RootParseResult<IRootContentItem> FromResult(T value)
        {
            return new RootParseResult<IRootContentItem>(value, RootParseResultKind.Success);
        }

        public static RootParseResult<IRootContentItem> FromError(string errorMessage)
        {
            return new RootParseResult<IRootContentItem>(errorMessage, RootParseResultKind.Error);
        }
    }
}
