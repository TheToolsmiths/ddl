using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public class ModelConfigurationRegistry : IModelConfigurationRegistry
    {
        private readonly IReadOnlyDictionary<string, ModelConfigurationSection> sections;

        public ModelConfigurationRegistry(IReadOnlyDictionary<string, ModelConfigurationSection> sections)
        {
            this.sections = sections;
        }

        public bool TryGetSection(string sectionKey, [MaybeNullWhen(false)] out IModelConfigurationSection configurationSection)
        {
            if (this.sections.TryGetValue(sectionKey, out var section))
            {
                configurationSection = section;
                return true;
            }

            configurationSection = default;
            return false;
        }
    }
}
