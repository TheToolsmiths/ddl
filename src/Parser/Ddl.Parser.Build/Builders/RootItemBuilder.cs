using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class RootItemBuilder
    {
        private readonly RootBuilderResolver builderResolver;

        public RootItemBuilder(RootBuilderResolver builderResolver)
        {
            this.builderResolver = builderResolver;
        }

        public Result BuildItem(IRootItemBuildContext context, IAstRootItem item)
        {
            if (this.builderResolver.TryResolveItemBuilder(item, out var itemBuilder) == false)
            {
                throw new NotImplementedException();
            }

            var result = itemBuilder.BuildItem(context, item);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
            return Result.Success;
        }
    }
}
