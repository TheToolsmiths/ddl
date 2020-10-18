using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Compiler.Configurations
{
    public interface ICompilerConfigurationBuilder : IConfigurationBuilder
    {
        void RegisterCompiler<T>(ItemType itemType)
            where T : IItemCompiler;

        void RegisterCompiler<T>(ScopeType scopeType)
            where T : IScopeCompiler;
    }
}
