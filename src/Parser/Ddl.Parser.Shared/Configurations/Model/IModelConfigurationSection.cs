using System;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationSection
    {
        bool TryGetTypeValue(ItemType itemType, [NotNullWhen(true)] out Type? typeValue);

        bool TryGetTypeValue(ScopeType scopeType, [NotNullWhen(true)] out Type? typeValue);
    }
}
