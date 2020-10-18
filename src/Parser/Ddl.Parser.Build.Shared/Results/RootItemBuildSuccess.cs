using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Items;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootItemBuildSuccess : RootItemBuildResult
    {
        public RootItemBuildSuccess(IReadOnlyList<IRootItem> items)
            : base(RootItemBuildResultKind.Success)
        {
            this.Items = items;
        }

        public IReadOnlyList<IRootItem> Items { get; }
    }
}
