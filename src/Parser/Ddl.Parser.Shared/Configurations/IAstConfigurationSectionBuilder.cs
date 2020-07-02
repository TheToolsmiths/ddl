using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public interface IAstConfigurationSectionBuilder
    {
    }

    public interface IAstConfigurationSectionBuilder<in T> : IAstConfigurationSectionBuilder
    {
        void RegisterTypeValue<TValue>(AstItemType itemType)
            where TValue : T;

        void RegisterTypeValue<TValue>(AstScopeType scopeType)
            where TValue : T;
    }
}
