using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootItemBuildResult<T> : RootItemBuildResult
        where T : class, IRootItem
    {
        internal RootItemBuildResult(T value, RootItemBuildResultKind resultKind)
            : base(resultKind)
        {
            this.Value = value;
        }

        internal RootItemBuildResult(string errorMessage, RootItemBuildResultKind resultKind)
            : base(errorMessage, resultKind)
        {
            this.Value = default!;
        }

        internal RootItemBuildResult(T value, IEnumerable<string> parserLookupIdentifiers, RootItemBuildResultKind resultKind)
            : base(parserLookupIdentifiers, resultKind)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}
