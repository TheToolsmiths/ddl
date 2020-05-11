using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser
{
    public class RootParseResult<T>
        where T : class, IRootContentEntry
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

        public static RootParseResult<T> CreateParserHandlerNotFound(IEnumerable<string> parserLookupIdentifiers)
        {
            return new RootParseResult<T>(default!, parserLookupIdentifiers, RootParseResultKind.ParserHandlerNotFound);
        }

        public static RootParseResult<T> FromResult(T value)
        {
            return new RootParseResult<T>(value, RootParseResultKind.Success);
        }

        public static RootParseResult<T> FromError(string errorMessage)
        {
            return new RootParseResult<T>(errorMessage, RootParseResultKind.Error);
        }

        public RootParseResult<TResult> As<TResult>()
            where TResult : class, IRootContentEntry
        {
            return this.ResultKind switch
            {
                RootParseResultKind.Success => RootParseResult<TResult>.FromResult(this.Value as TResult ?? throw new ArgumentException()),
                RootParseResultKind.Error => RootParseResult<TResult>.FromError(this.ErrorMessage),
                RootParseResultKind.ParserHandlerNotFound => RootParseResult<TResult>.CreateParserHandlerNotFound(this.ParserLookupIdentifiers),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
