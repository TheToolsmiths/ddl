using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public class RootItemResultBuilder
    {
        public RootItemResultBuilder()
        {
            this.Items = new List<IRootItem>();
        }

        public List<IRootItem> Items { get; }

        public RootItemBuildSuccess CreateSuccessResult()
        {
            return new RootItemBuildSuccess(this.Items);
        }
    }
}
