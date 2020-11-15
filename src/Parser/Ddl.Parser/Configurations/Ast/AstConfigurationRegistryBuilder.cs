﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public class AstConfigurationRegistryBuilder : IAstConfigurationRegistryBuilder
    {
        private readonly Dictionary<string, AstConfigurationSectionBuilderBase> sectionBuilders;

        public AstConfigurationRegistryBuilder()
        {
            this.sectionBuilders =
                new Dictionary<string, AstConfigurationSectionBuilderBase>(StringComparer.OrdinalIgnoreCase);
        }

        public bool TryGetCategoryBuilder<TValue>(
            string sectionKey,
            [NotNullWhen(true)] out IAstConfigurationSectionBuilder<TValue>? sectionBuilder)
        {
            if (this.sectionBuilders.TryGetValue(sectionKey, out var builder) == false)
            {
                var typedBuilder = new AstConfigurationSectionBuilder<TValue>();

                this.sectionBuilders.Add(sectionKey, typedBuilder);

                sectionBuilder = typedBuilder;
                return true;
            }

            sectionBuilder = builder as IAstConfigurationSectionBuilder<TValue>;

            return sectionBuilder != null;
        }

        public bool TryGetCategoryBuilder(
            string sectionKey,
            [NotNullWhen(true)] out IAstConfigurationSectionBuilder? sectionBuilder)
        {
            if (this.sectionBuilders.TryGetValue(sectionKey, out var builder) == false)
            {
                var typedBuilder = new AstConfigurationSectionBuilder();

                this.sectionBuilders.Add(sectionKey, typedBuilder);

                sectionBuilder = typedBuilder;
                return true;
            }

            sectionBuilder = builder as IAstConfigurationSectionBuilder;

            return sectionBuilder != null;
        }

        public IAstConfigurationRegistry Build()
        {
            var sections = new Dictionary<string, AstConfigurationSection>(StringComparer.OrdinalIgnoreCase);

            foreach ((string sectionKey, var sectionBuilder) in this.sectionBuilders)
            {
                var section = sectionBuilder.Build();

                sections.Add(sectionKey, section);
            }

            return new AstConfigurationRegistry(sections);
        }
    }
}