using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public interface IWriterConfigurationRegistry
    {
        bool TryGetSection(string sectionKey, [NotNullWhen(true)] out IWriterConfigurationSection? configurationSection);
    }
}
