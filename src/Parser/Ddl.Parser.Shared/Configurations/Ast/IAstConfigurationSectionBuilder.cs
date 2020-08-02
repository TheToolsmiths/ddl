using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationSectionBuilder
    {
        void RegisterTypeValue(AstItemType itemType, Type value);

        void RegisterTypeValue(AstScopeType scopeType, Type value);
    }

    public interface IAstConfigurationSectionBuilder<in T>
    {
        void RegisterTypeValue<TValue>(AstItemType itemType)
            where TValue : T;

        void RegisterTypeValue<TValue>(AstScopeType scopeType)
            where TValue : T;
    }
}
