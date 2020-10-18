using System;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Parser.Compiler.Configurations;

namespace TheToolsmiths.Ddl.Parser.Compiler.Implementations.Configurators
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetCompilerConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            this.RegisterCompilers(builder);
        }

        private void RegisterCompilers(ICompilerConfigurationBuilder builder)
        {
            // Register Item Type Compilers
            {
                builder.RegisterCompiler<EnumDefinitionCompiler>(CommonItemTypes.EnumDefinition);
                builder.RegisterCompiler<EnumStructDefinitionCompiler>(CommonItemTypes.EnumStructDefinition);
                builder.RegisterCompiler<StructDefinitionCompiler>(CommonItemTypes.StructDefinition);
            }

            // Register Scope Compilers
            {
                builder.RegisterCompiler<RootScopeCompiler>(CommonScopeTypes.RootScope);
                builder.RegisterCompiler<ConditionalRootScopeCompiler>(CommonScopeTypes.ConditionalScope);
            }
        }
    }
}
