using System;
using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class ContentUnitItemResolverProvider
    {
        private readonly IServiceProvider provider;

        public ContentUnitItemResolverProvider(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public EnumDefinitionResolver CreateEnumDefinitionResolver()
        {
            return this.provider.GetRequiredService<EnumDefinitionResolver>();
        }

        public EnumStructDefinitionResolver CreateEnumStructDefinitionResolver()
        {
            return this.provider.GetRequiredService<EnumStructDefinitionResolver>();
        }

        public StructDefinitionResolver CreateStructDefinitionResolver()
        {
            return this.provider.GetRequiredService<StructDefinitionResolver>();
        }
    }
}
