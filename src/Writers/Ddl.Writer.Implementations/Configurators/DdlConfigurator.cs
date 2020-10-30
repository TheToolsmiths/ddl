using System;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Writer.Configurations.Writer;

namespace TheToolsmiths.Ddl.Writer.Implementations.Configurators
{
    public class DdlConfigurator : IDdlConfigurator
    {
        public void Configure(IDdlConfigurationContext context)
        {
            if (context.TryGetDefinitionWriterConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            RegisterWriters(builder);
        }

        private static void RegisterWriters(IDefinitionWriterConfigurationBuilder builder)
        {
            builder.RegisterItemWriter<CompiledStructDefinitionWriter>(CommonItemTypes.StructDefinition);

            builder.RegisterItemWriter<CompiledEnumStructDefinitionWriter>(CommonItemTypes.EnumStructDefinition);

            builder.RegisterItemWriter<CompiledEnumDefinitionWriter>(CommonItemTypes.EnumDefinition);
            
            builder.RegisterSubItemWriter<CompiledEnumConstantDefinitionWriter>(CommonSubItemTypes.EnumConstantDefinition);

            builder.RegisterSubItemWriter<CompiledEnumStructVariantDefinitionWriter>(CommonSubItemTypes.EnumStructVariantDefinition);
        }
    }
}
