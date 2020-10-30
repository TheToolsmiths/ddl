using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public class WriterConfigurationRegistry : IWriterConfigurationRegistry
    {
        private readonly IReadOnlyDictionary<string, WriterConfigurationSection> sections;

        public WriterConfigurationRegistry(IReadOnlyDictionary<string, WriterConfigurationSection> sections)
        {
            this.sections = sections;
        }

        public bool TryGetSection(string sectionKey, [NotNullWhen(true)] out IWriterConfigurationSection? configurationSection)
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
