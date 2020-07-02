using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    internal abstract class AstConfigurationSectionBuilderBase
    {
        private readonly Dictionary<AstItemType, Type> itemBuilders;
        private readonly Dictionary<AstScopeType, Type> scopeBuilders;

        protected AstConfigurationSectionBuilderBase()
        {
            this.itemBuilders = new Dictionary<AstItemType, Type>();
            this.scopeBuilders = new Dictionary<AstScopeType, Type>();
        }

        protected void RegisterTypeValue(AstItemType itemType, Type typeValue)
        {
            this.itemBuilders.Add(itemType, typeValue);
        }

        protected void RegisterTypeValue(AstScopeType scopeType, Type typeValue)
        {
            this.scopeBuilders.Add(scopeType, typeValue);
        }

        public AstConfigurationSection Build()
        {
            return new AstConfigurationSection(this.itemBuilders, this.scopeBuilders);
        }
    }
}
