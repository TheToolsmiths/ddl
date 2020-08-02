using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public class ModelConfigurationRegistryBuilder : IModelConfigurationRegistryBuilder
    {
        private readonly Dictionary<string, ModelConfigurationSectionBuilderBase> sectionBuilders;

        public ModelConfigurationRegistryBuilder()
        {
            this.sectionBuilders =
                new Dictionary<string, ModelConfigurationSectionBuilderBase>(StringComparer.OrdinalIgnoreCase);
        }

        public bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [MaybeNullWhen(false)] out IModelConfigurationSectionBuilder<TValue> sectionBuilder)
        {
            if (this.sectionBuilders.TryGetValue(sectionKey, out var builder) == false)
            {
                var typedBuilder = new ModelConfigurationSectionBuilder<TValue>();

                this.sectionBuilders.Add(sectionKey, typedBuilder);

                sectionBuilder = typedBuilder;
                return true;
            }

            sectionBuilder = builder as IModelConfigurationSectionBuilder<TValue>;

            return sectionBuilder != null;
        }

        public bool TryGetCategoryBuilder(string sectionKey, out IModelConfigurationSectionBuilder sectionBuilder)
        {
            if (this.sectionBuilders.TryGetValue(sectionKey, out var builder) == false)
            {
                var typedBuilder = new ModelConfigurationSectionBuilder();

                this.sectionBuilders.Add(sectionKey, typedBuilder);

                sectionBuilder = typedBuilder;
                return true;
            }

            sectionBuilder = builder as IModelConfigurationSectionBuilder ?? throw new InvalidOperationException();

            return sectionBuilder != null;
        }

        public IModelConfigurationRegistry Build()
        {
            var sections = new Dictionary<string, ModelConfigurationSection>(StringComparer.OrdinalIgnoreCase);

            foreach ((string sectionKey, var sectionBuilder) in this.sectionBuilders)
            {
                var section = sectionBuilder.Build();

                sections.Add(sectionKey, section);
            }

            return new ModelConfigurationRegistry(sections);
        }
    }
}
