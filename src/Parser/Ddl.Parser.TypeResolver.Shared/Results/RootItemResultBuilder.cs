using System;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootItemResultBuilder
    {
        public IRootItem? Item { get; set; }

        public RootItemTypeResolveSuccess CreateSuccessResult()
        {
            if (this.Item == null)
            {
                throw new NotImplementedException();
            }

            return new RootItemTypeResolveSuccess(this.Item);
        }
    }
}
