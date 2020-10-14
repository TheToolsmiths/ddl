using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public class ModelConfigurationSection : IModelConfigurationSection
    {
        private readonly IReadOnlyDictionary<ItemType, Type> itemBuilders;
        private readonly IReadOnlyDictionary<ScopeType, Type> scopeBuilders;

        public ModelConfigurationSection(
            IReadOnlyDictionary<ItemType, Type> itemBuilders,
            IReadOnlyDictionary<ScopeType, Type> scopeBuilders)
        {
            this.itemBuilders = itemBuilders;
            this.scopeBuilders = scopeBuilders;
        }

        public bool TryGetTypeValue(ItemType itemType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.itemBuilders.TryGetValue(itemType, out typeValue);
        }

        public bool TryGetTypeValue(ScopeType scopeType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.scopeBuilders.TryGetValue(scopeType, out typeValue);
        }
    }
}
