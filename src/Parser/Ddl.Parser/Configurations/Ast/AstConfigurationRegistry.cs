using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public class AstConfigurationRegistry : IAstConfigurationRegistry
    {
        private readonly IReadOnlyDictionary<string, AstConfigurationSection> sections;

        public AstConfigurationRegistry(IReadOnlyDictionary<string, AstConfigurationSection> sections)
        {
            this.sections = sections;
        }

        public bool TryGetSection(string sectionKey, [NotNullWhen(true)] out IAstConfigurationSection? configurationSection)
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
