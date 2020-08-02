using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Model
{
    public interface IModelConfigurationRegistry
    {
        bool TryGetSection(string sectionKey, [MaybeNullWhen(false)] out IModelConfigurationSection configurationSection);
    }
}
