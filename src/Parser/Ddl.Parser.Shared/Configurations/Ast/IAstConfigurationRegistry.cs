using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public interface IAstConfigurationRegistry
    {
        bool TryGetSection(string sectionKey, [MaybeNullWhen(false)] out IAstConfigurationSection configurationSection);
    }
}
