using System;
using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public interface IAstConfigurationSection
    {
        bool TryGetTypeValue(AstItemType itemType, [MaybeNullWhen(false)] out Type typeValue);

        bool TryGetTypeValue(AstScopeType scopeType, [MaybeNullWhen(false)] out Type typeValue);
    }
}
