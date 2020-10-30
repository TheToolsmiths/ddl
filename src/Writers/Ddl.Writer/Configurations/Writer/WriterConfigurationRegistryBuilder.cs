using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public class WriterConfigurationRegistryBuilder : IWriterConfigurationRegistryBuilder
    {
        private readonly Dictionary<string, WriterConfigurationSectionBuilderBase> sectionBuilders;

        public WriterConfigurationRegistryBuilder()
        {
            this.sectionBuilders =
                new Dictionary<string, WriterConfigurationSectionBuilderBase>(StringComparer.OrdinalIgnoreCase);
        }

        public bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [NotNullWhen(true)] out IWriterConfigurationSectionBuilder<TValue>? sectionBuilder)
        {
            if (this.sectionBuilders.TryGetValue(sectionKey, out var builder) == false)
            {
                var typedBuilder = new WriterConfigurationSectionBuilder<TValue>();

                this.sectionBuilders.Add(sectionKey, typedBuilder);

                sectionBuilder = typedBuilder;
                return true;
            }

            sectionBuilder = builder as IWriterConfigurationSectionBuilder<TValue>;

            return sectionBuilder != null;
        }

        public bool TryGetCategoryBuilder(string sectionKey, [NotNullWhen(true)] out IWriterConfigurationSectionBuilder? sectionBuilder)
        {
            if (this.sectionBuilders.TryGetValue(sectionKey, out var builder) == false)
            {
                var typedBuilder = new WriterConfigurationSectionBuilder();

                this.sectionBuilders.Add(sectionKey, typedBuilder);

                sectionBuilder = typedBuilder;
                return true;
            }

            sectionBuilder = builder as IWriterConfigurationSectionBuilder;

            return sectionBuilder != null;
        }

        public IWriterConfigurationRegistry Build()
        {
            var sections = new Dictionary<string, WriterConfigurationSection>(StringComparer.OrdinalIgnoreCase);

            foreach ((string sectionKey, var sectionBuilder) in this.sectionBuilders)
            {
                var section = sectionBuilder.Build();

                sections.Add(sectionKey, section);
            }

            return new WriterConfigurationRegistry(sections);
        }
    }
}
