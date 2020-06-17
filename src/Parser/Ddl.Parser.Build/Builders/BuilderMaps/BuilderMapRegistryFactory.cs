using System;

using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.BuilderMaps
{
    public static class BuilderMapRegistryFactory
    {
        public static IBuilderMapRegistry CreateMap(IServiceProvider provider)
        {
            var builder = new BuilderMapRegistryBuilder();

            using (var _ = provider.CreateScope())
            {
                var parserProviders = provider.GetServices<IRootBuilderRegister>();

                foreach (var parserProvider in parserProviders)
                {
                    parserProvider.RegisterBuilders(builder);
                }
            }

            return builder.Build();
        }
    }
}
