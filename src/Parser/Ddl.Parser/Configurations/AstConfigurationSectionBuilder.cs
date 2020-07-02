﻿using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    internal class AstConfigurationSectionBuilder<T> : AstConfigurationSectionBuilderBase, IAstConfigurationSectionBuilder<T>
    {
        public void RegisterTypeValue<TValue>(AstItemType itemType)
            where TValue : T
        {
            base.RegisterTypeValue(itemType, typeof(TValue));
        }

        public void RegisterTypeValue<TValue>(AstScopeType scopeType)
            where TValue : T
        {
            base.RegisterTypeValue(scopeType, typeof(TValue));
        }
    }
}
