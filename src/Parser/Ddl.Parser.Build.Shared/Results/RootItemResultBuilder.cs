using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Items;

namespace TheToolsmiths.Ddl.Parser.Build.Results
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
