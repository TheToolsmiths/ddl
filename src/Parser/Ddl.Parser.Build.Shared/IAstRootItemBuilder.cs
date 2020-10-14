﻿using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IAstRootItemBuilder
    {
        RootItemBuildResult BuildItem(IRootItemBuildContext context, IAstRootItem item);
    }
}
