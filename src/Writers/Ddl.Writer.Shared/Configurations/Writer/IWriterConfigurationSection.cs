using System;
using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public interface IWriterConfigurationSection
    {
        bool TryGetTypeValue(ItemType itemType, [NotNullWhen(true)] out Type? typeValue);

        bool TryGetTypeValue(ScopeType scopeType, [NotNullWhen(true)] out Type? typeValue);

        bool TryGetTypeValue(SubItemType subItemType, [NotNullWhen(true)] out Type? typeValue);
    }
}
