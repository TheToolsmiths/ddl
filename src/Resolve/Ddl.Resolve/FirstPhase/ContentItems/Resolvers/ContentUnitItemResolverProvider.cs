using System;
using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class ContentUnitItemResolverProvider
    {
        private readonly IServiceProvider provider;

        public ContentUnitItemResolverProvider(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public RootScopeResolver CreateRootScopeResolver()
        {
            return this.provider.GetRequiredService<RootScopeResolver>();
        }

        public EnumDefinitionResolver CreateEnumDefinitionResolver()
        {
            return this.provider.GetRequiredService<EnumDefinitionResolver>();
        }

        public EnumStructDefinitionResolver CreateEnumStructDefinitionResolver()
        {
            return this.provider.GetRequiredService<EnumStructDefinitionResolver>();
        }

        public ImportStatementResolver CreateImportStatementResolver()
        {
            return this.provider.GetRequiredService<ImportStatementResolver>();
        }

        public StructDefinitionResolver CreateStructDefinitionResolver()
        {
            return this.provider.GetRequiredService<StructDefinitionResolver>();
        }
    }
}
