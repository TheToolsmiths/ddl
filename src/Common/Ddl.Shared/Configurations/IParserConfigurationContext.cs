using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public interface IParserConfigurationContext
    {
        bool TryGetConfigurationProvider<T>([MaybeNullWhen(false)] out T provider)
            where T : IConfigurationProvider;
    }
}
