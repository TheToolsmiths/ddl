using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class AstRootItemBuilder : IAstRootItemBuilder
    {
        private readonly RootBuilderResolver builderResolver;

        public AstRootItemBuilder(RootBuilderResolver builderResolver)
        {
            this.builderResolver = builderResolver;
        }

        public RootItemBuildResult BuildItem(IRootItemBuildContext context, IAstRootItem item)
        {
            if (this.builderResolver.TryResolveItemBuilder(item, out var itemBuilder) == false)
            {
                throw new NotImplementedException();
            }

            return itemBuilder.BuildItem(context, item);
        }
    }
}
