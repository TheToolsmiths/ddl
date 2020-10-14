using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationSection
    {
        bool TryGetTypeValue(AstItemType itemType, [NotNullWhen(true)] out Type? typeValue);

        bool TryGetTypeValue(AstScopeType scopeType, [NotNullWhen(true)] out Type? typeValue);
    }
}
