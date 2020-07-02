﻿using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IRootBuilderResolver
    {
        // TODO: Change so that the lookup is made with a RootItem Type key and not the AST item

        bool TryResolveItemBuilder(IAstRootItem astItem, [MaybeNullWhen(false)] out IRootItemBuilder itemBuilder);

        bool TryResolveScopeBuilder(IAstRootScope astScope, [MaybeNullWhen(false)] out IRootScopeBuilder scopeBuilder);
    }
}