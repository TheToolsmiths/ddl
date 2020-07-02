using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Build.Configurations
{
    public interface IBuilderConfigurationBuilder : IConfigurationBuilder
    {
        void RegisterItemBuilder<T>(AstItemType itemType);

        void RegisterScopeBuilder<T>(AstScopeType scopeType);
    }
}
