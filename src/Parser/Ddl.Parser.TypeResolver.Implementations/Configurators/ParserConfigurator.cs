using System;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Configurations;
using TheToolsmiths.Ddl.Parser.TypeResolver.Extensions;

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
                builder.RegisterItemTypeResolver<EnumDefinitionTypeResolver>(CommonItemTypes.EnumDefinition);
                builder.RegisterItemTypeResolver<EnumStructDefinitionTypeResolver>(
                    CommonItemTypes.EnumStructDefinition);
                builder.RegisterItemTypeResolver<StructDefinitionTypeResolver>(CommonItemTypes.StructDefinition);
            }

            // Register Scope Type Resolvers
            {
                builder.RegisterScopeTypeResolver<RootScopeTypeResolver>(CommonScopeTypes.RootScope);
                builder.RegisterScopeTypeResolver<ConditionalRootScopeTypeResolver>(CommonScopeTypes.ConditionalScope);
            }
        }
    }
}
