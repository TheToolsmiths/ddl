using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Configurations.Model;

namespace TheToolsmiths.Ddl.Parser.Compiler.Configurations
{
    public class CompilerConfigurationBuilder : ConfigurationBuilder, ICompilerConfigurationBuilder
    {
        private readonly Dictionary<ItemType, Type> itemCompilers;
        private readonly Dictionary<ScopeType, Type> scopeCompilers;

        public CompilerConfigurationBuilder()
        {
            this.itemCompilers = new Dictionary<ItemType, Type>();
            this.scopeCompilers = new Dictionary<ScopeType, Type>();
        }

        public void RegisterCompiler<T>(ItemType itemType)
            where T : IItemCompiler
        {
            this.itemCompilers.Add(itemType, typeof(T));
        }

        public void RegisterCompiler<T>(ScopeType scopeType)
            where T : IScopeCompiler
        {
            this.scopeCompilers.Add(scopeType, typeof(T));
        }

        public override void Configure(ConfigurationBuilderContext context)
        {
            if (context.ProviderCollection.TryGetConfigurationProvider<IModelConfigurationProvider>(out var provider) == false)
            {
                throw new NotImplementedException();
            }

            if (provider.RegistryBuilder.TryGetCategoryBuilder(ConfigurationKeys.ResolveConfigurationSection, out var section) == false)
            {
                throw new NotImplementedException();
            }

            foreach (var (itemType, itemCompilerType) in this.itemCompilers)
            {
                section.RegisterTypeValue(itemType, itemCompilerType);

                context.Services.AddTransient(itemCompilerType);
            }

            foreach (var (scopeType, scopeCompilerType) in this.scopeCompilers)
            {
                section.RegisterTypeValue(scopeType, scopeCompilerType);

                context.Services.AddTransient(scopeCompilerType);
            }
        }
    }
}
