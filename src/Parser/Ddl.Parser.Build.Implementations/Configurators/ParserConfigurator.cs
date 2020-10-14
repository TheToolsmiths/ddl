using System;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Parser.Build.Configurations;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Configurators
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetBuilderConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            this.RegisterBuilders(builder);
        }

        private void RegisterBuilders(IBuilderConfigurationBuilder builder)
        {
            // Register Item Builders
            {
                builder.RegisterItemBuilder<EnumDefinitionBuilder>(CommonItemTypes.EnumDeclaration);
                builder.RegisterItemBuilder<EnumStructDefinitionBuilder>(CommonItemTypes.EnumStructDeclaration);
                builder.RegisterItemBuilder<StructDefinitionBuilder>(CommonItemTypes.StructDeclaration);
                builder.RegisterItemBuilder<ImportStatementBuilder>(CommonItemTypes.ImportStatement);
            }

            // Register Scope Builders
            {
                builder.RegisterScopeBuilder<RootScopeBuilder>(CommonScopeTypes.RootScope);
                builder.RegisterScopeBuilder<ConditionalRootScopeBuilder>(CommonScopeTypes.ConditionalScope);
            }
        }
    }
}
