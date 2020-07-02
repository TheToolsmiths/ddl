using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Build.Configurations;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetItemConfigurationBuilder(out var itemBuilder))
            {
                itemBuilder.RegisterTypeValue<EnumDefinitionBuilder>(CommonItemTypes.EnumDeclaration);
                itemBuilder.RegisterTypeValue<EnumStructDefinitionBuilder>(CommonItemTypes.EnumStructDeclaration);
                itemBuilder.RegisterTypeValue<StructDefinitionBuilder>(CommonItemTypes.StructDeclaration);
                itemBuilder.RegisterTypeValue<ImportStatementBuilder>(CommonItemTypes.ImportStatement);
            }

            if (context.TryGetScopeConfigurationBuilder(out var scopeBuilder))
            {
                scopeBuilder.RegisterTypeValue<RootScopeBuilder>(CommonScopeTypes.RootScope);
                scopeBuilder.RegisterTypeValue<ConditionalRootScopeBuilder>(CommonScopeTypes.ConditionalScope);
            }
        }
    }
}
