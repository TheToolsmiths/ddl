using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Scopes;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Common
{
    public class CommonCompilers : ICommonCompilers
    {
        private readonly IServiceProvider provider;
        private readonly IRootScopeCompileContext context;

        public CommonCompilers(IServiceProvider serviceProvider, IRootScopeCompileContext context)
        {
            this.provider = serviceProvider;
            this.context = context;
        }

        public CommonCompilers CreateForScope(IRootScopeCompileContext scopeContext)
        {
            return new CommonCompilers(this.provider, scopeContext);
        }

        public Result<CompiledScopeContent> CompileScopeContent(ScopeContent scopeContent)
        {
            return this.provider.GetRequiredService<ScopeContentCompiler>().CompileScopeContent(this.context, scopeContent);
        }

        public Result<CompiledAttributeUseCollection> CompileAttributes(AttributeUseCollection attributes)
        {
            return this.provider.GetRequiredService<AttributesCompiler>().CompileAttributes(this.context, attributes);
        }

        public Result<CompiledStructContent> CompileStructDefinitionContent(StructContent content)
        {
            return this.provider.GetRequiredService<StructDefinitionContentCompiler>().Compile(this.context, content);
        }

        public Result<CompiledValueInitialization> CompileValueInitialization(ValueInitialization initialization)
        {
            return this.provider.GetRequiredService<ValueInitializationCompiler>().Compile(this.context, initialization);
        }

        public Result<CompiledStructInitialization> CompileStructInitialization(StructInitialization initialization)
        {
            return this.provider.GetRequiredService<ValueInitializationCompiler>().CompileStructInitialization(this.context, initialization);
        }
    }
}
