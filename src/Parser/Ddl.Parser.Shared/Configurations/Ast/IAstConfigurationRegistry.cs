using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationRegistry
    {
        bool TryGetSection(string sectionKey, [NotNullWhen(true)] out IAstConfigurationSection? configurationSection);
    }
}
