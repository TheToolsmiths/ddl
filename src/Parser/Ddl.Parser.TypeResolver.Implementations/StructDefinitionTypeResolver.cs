using System;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class StructDefinitionTypeResolver : IItemTypeResolver<StructDefinition>
    {
        public RootItemTypeResolveResult ResolveItemTypes(IRootItemTypeResolveContext itemContext, StructDefinition item)
        {
            var updatedItemContext = itemContext.AddTypeNameInfoToContext(item.TypeName);

            var builder = new RootItemResultBuilder();

            AttributeUseCollection attributes;
            {
                var result = updatedItemContext.CommonTypeResolvers.ResolveAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            StructDefinitionContent structContent;
            {
                var result = updatedItemContext.CommonTypeResolvers.ResolveStructDefinitionContent(item.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                structContent = result.Value;
            }

            var typeNameResolution = updatedItemContext.TypeNameResolver.Resolve(item.TypeName);

            builder.Item = new StructDefinition(item.ItemId, item.TypeName, typeNameResolution, structContent, attributes);

            return builder.CreateSuccessResult();
        }
    }
}
