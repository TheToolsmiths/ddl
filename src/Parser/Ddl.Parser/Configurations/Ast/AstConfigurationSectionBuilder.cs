using System;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    internal class AstConfigurationSectionBuilder : AstConfigurationSectionBuilderBase, IAstConfigurationSectionBuilder
    {
        public new void RegisterTypeValue(AstItemType itemType, Type value)
        {
            base.RegisterTypeValue(itemType, value);
        }

        public new void RegisterTypeValue(AstScopeType scopeType, Type value)
        {
            base.RegisterTypeValue(scopeType, value);
        }
    }

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
