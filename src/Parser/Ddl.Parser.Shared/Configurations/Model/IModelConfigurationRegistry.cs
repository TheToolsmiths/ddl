using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationRegistry
    {
        bool TryGetSection(string sectionKey, [NotNullWhen(true)] out IModelConfigurationSection? configurationSection);
    }
}
