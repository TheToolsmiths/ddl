using System;

using TheToolsmiths.Ddl.Models.Build.Structs;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Structs;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Implementations
{
    internal class StructDefinitionCompiler : IItemCompiler<StructDefinition>
    {
        public RootItemCompileResult CompileItem(IRootItemCompileContext itemContext, StructDefinition item)
        {
            var updatedItemContext = itemContext.AddTypeNameInfoToContext(item.TypeName);

            var builder = new RootItemResultBuilder();

            CompiledAttributeUseCollection attributes;
            {
                var result = updatedItemContext.CommonCompilers.CompileAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            CompiledStructContent structContent;
            {
                var result = updatedItemContext.CommonCompilers.CompileStructDefinitionContent(item.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                structContent = result.Value;
            }

            var typeName = updatedItemContext.TypeNameResolver.Resolve(item.TypeName);

            builder.Item = new CompiledStructDefinition(item.ItemId, typeName, structContent, attributes);

            return builder.CreateSuccessResult();
        }
    }
}
