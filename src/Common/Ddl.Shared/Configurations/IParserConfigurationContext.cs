using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public interface IParserConfigurationContext
    {
        bool TryGetConfigurationBuilder<T>([MaybeNullWhen(false)] out T builder)
            where T : class, IConfigurationBuilder;
    }
}
