using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Parser.Compiler.Configurations
{
    public static class ResolveConfigurationExtensions
    {
        public static bool TryGetCompilerConfigurationBuilder(
            this IDdlConfigurationContext context,
            [NotNullWhen(true)] out ICompilerConfigurationBuilder? configurationBuilder)
        {
            return context.TryGetConfigurationBuilder(out configurationBuilder);
        }
    }
}
