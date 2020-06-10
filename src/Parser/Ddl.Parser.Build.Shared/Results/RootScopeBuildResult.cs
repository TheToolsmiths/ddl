using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootScopeBuildResult
    {
        protected RootScopeBuildResult(RootScopeBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = string.Empty;
        }

        protected RootScopeBuildResult(string errorMessage, RootScopeBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = Array.Empty<string>();
            this.ErrorMessage = errorMessage;
        }

        protected RootScopeBuildResult(IEnumerable<string> parserLookupIdentifiers, RootScopeBuildResultKind resultKind)
        {
            this.ResultKind = resultKind;
            this.ParserLookupIdentifiers = parserLookupIdentifiers.ToList();
            this.ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; }

        public bool IsSuccess => this.ResultKind == RootScopeBuildResultKind.Success;

        public bool IsError => this.ResultKind != RootScopeBuildResultKind.Success;

        public IReadOnlyList<string> ParserLookupIdentifiers { get; }

        public RootScopeBuildResultKind ResultKind { get; }

        public static RootScopeBuildResult FromError(string errorMessage)
        {
            return new RootScopeBuildResult(errorMessage, RootScopeBuildResultKind.Error);
        }

        public static RootScopeBuildResult<T> FromResult<T>(T value)
            where T : class, IRootScope
        {
            return new RootScopeBuildResult<T>(value, RootScopeBuildResultKind.Success);
        }

        public static RootScopeBuildResult<T> FromError<T>(string errorMessage)
            where T : class, IRootScope
        {
            return new RootScopeBuildResult<T>(errorMessage, RootScopeBuildResultKind.Error);
        }
    }
}
