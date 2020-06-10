using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootScopeBuildResult<T> : RootScopeBuildResult
        where T : class, IRootScope
    {
        internal RootScopeBuildResult(T value, RootScopeBuildResultKind resultKind)
            : base(resultKind)
        {
            this.Value = value;
        }

        internal RootScopeBuildResult(string errorMessage, RootScopeBuildResultKind resultKind)
            : base(errorMessage, resultKind)
        {
            this.Value = default!;
        }

        internal RootScopeBuildResult(T value, IEnumerable<string> parserLookupIdentifiers, RootScopeBuildResultKind resultKind)
            : base(parserLookupIdentifiers, resultKind)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}
