using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Scopes;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface ICommonCompilers
    {
        Result<CompiledScopeContent> CompileScopeContent(ScopeContent scopeContent);

        Result<CompiledAttributeUseCollection> CompileAttributes(AttributeUseCollection attributes);

        Result<CompiledStructContent> CompileStructDefinitionContent(StructContent content);

        Result<CompiledValueInitialization> CompileValueInitialization(ValueInitialization initialization);

        Result<CompiledStructInitialization> CompileStructInitialization(StructInitialization initialization);
    }
}
