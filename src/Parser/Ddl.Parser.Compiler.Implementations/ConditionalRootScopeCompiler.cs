using System;

using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Implementations
{
    internal class ConditionalRootScopeCompiler : IScopeCompiler<ConditionalRootScope>
    {
        public RootScopeCompileResult ResolveScopeTypes(IRootScopeCompileContext scopeContext, ConditionalRootScope scope)
        {
            CompiledScopeContent scopeContent;
            {
                var result = scopeContext.CommonCompilers.CompileScopeContent(scope.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                scopeContent = result.Value;
            }

            CompiledAttributeUseCollection attributes;
            {
                var result = scopeContext.CommonCompilers.CompileAttributes(scope.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var resolvedScope = new ConditionalCompiledScope(scope.ConditionalExpression, scopeContent, attributes);

            return new RootScopeCompileSuccess(resolvedScope);
        }
    }
}
