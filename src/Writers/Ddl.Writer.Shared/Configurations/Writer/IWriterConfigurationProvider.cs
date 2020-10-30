using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Writer.Configurations.Writer
{
    public interface IWriterConfigurationProvider : IConfigurationProvider
    {
        IWriterConfigurationRegistryBuilder RegistryBuilder { get; }
    }
}
