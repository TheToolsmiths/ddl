using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootItemBuildResult
    {
        protected RootItemBuildResult(RootItemBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = string.Empty;
        }

        protected RootItemBuildResult(string errorMessage, RootItemBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = errorMessage;
        }

        protected RootItemBuildResult(IEnumerable<string> parserLookupIdentifiers, RootItemBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = parserLookupIdentifiers.ToList();
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess => this.ResultKind == RootItemBuildResultKind.Success;

        public bool IsError => this.ResultKind != RootItemBuildResultKind.Success;

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }

        public RootItemBuildResultKind ResultKind { get; }

        public static RootItemBuildResult FromError(string errorMessage)
        {
            return new RootItemBuildResult(errorMessage, RootItemBuildResultKind.Error);
        }

        public static RootItemBuildResult<T> FromResult<T>(T value)
            where T : class, IRootItem
        {
            return new RootItemBuildResult<T>(value, RootItemBuildResultKind.Success);
        }

        public static RootItemBuildResult<T> FromError<T>(string errorMessage)
            where T : class, IRootItem
        {
            return new RootItemBuildResult<T>(errorMessage, RootItemBuildResultKind.Error);
        }
    }
}
