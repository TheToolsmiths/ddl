using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public interface IAstConfigurationRegistry
    {
        bool TryGetSection(string sectionKey, [MaybeNullWhen(false)] out IAstConfigurationSection configurationSection);
    }
}
