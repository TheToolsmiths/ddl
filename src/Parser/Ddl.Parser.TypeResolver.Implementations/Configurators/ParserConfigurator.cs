using System;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations.Configurators
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetTypeResolverConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            this.RegisterTypeResolvers(builder);
        }

        private void RegisterTypeResolvers(ITypeResolveConfigurationBuilder builder)
        {
            // Register Item Type Resolvers
            {
                builder.RegisterPassthroughTypeResolver(CommonItemTypes.ImportStatement);
                builder.RegisterTypeResolver<EnumDefinitionTypeResolver>(CommonItemTypes.EnumDefinition);
                builder.RegisterTypeResolver<EnumStructDefinitionTypeResolver>(
                    CommonItemTypes.EnumStructDefinition);
                builder.RegisterTypeResolver<StructDefinitionTypeResolver>(CommonItemTypes.StructDefinition);
            }

            // Register Scope Type Resolvers
            {
                builder.RegisterTypeResolver<RootScopeTypeResolver>(CommonScopeTypes.RootScope);
                builder.RegisterTypeResolver<ConditionalRootScopeTypeResolver>(CommonScopeTypes.ConditionalScope);
            }
        }
    }
}
