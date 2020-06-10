using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser
{
    public class RootParseResult<T> : RootParseResult
        where T : class, IAstRootEntry
    {
        internal RootParseResult(T value, RootParseResultKind resultKind)
            : base(resultKind)
        {
            this.Value = value;
        }

        internal RootParseResult(string errorMessage, RootParseResultKind resultKind)
            : base(errorMessage, resultKind)
        {
            this.Value = default!;
        }

        internal RootParseResult(T value, IEnumerable<string> parserLookupIdentifiers, RootParseResultKind resultKind)
            : base(parserLookupIdentifiers, resultKind)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}
