using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public class WriterConfigurationSection : IWriterConfigurationSection
    {
        private readonly IReadOnlyDictionary<ItemType, Type> itemWriters;
        private readonly IReadOnlyDictionary<SubItemType, Type> subItemWriters;
        private readonly IReadOnlyDictionary<ScopeType, Type> scopeWriters;

        public WriterConfigurationSection(
            IReadOnlyDictionary<ItemType, Type> itemWriters,
            IReadOnlyDictionary<SubItemType, Type> subItemWriters,
            IReadOnlyDictionary<ScopeType, Type> scopeWriters)
        {
            this.itemWriters = itemWriters;
            this.scopeWriters = scopeWriters;
            this.subItemWriters = subItemWriters;
        }

        public bool TryGetTypeValue(ItemType itemType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.itemWriters.TryGetValue(itemType, out typeValue);
        }

        public bool TryGetTypeValue(SubItemType subItemType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.subItemWriters.TryGetValue(subItemType, out typeValue);
        }

        public bool TryGetTypeValue(ScopeType scopeType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.scopeWriters.TryGetValue(scopeType, out typeValue);
        }
    }
}
