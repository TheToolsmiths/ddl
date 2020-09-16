using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class StructDefinitionTypeResolver : IItemTypeResolver<StructDefinition>
    {
        public RootItemTypeResolveResult ResolveItemTypes(IRootItemTypeResolveContext itemContext, StructDefinition item)
        {
            var updatedItemContext = this.AddTypeNameGenericParamsToContext(itemContext, item.TypeName);

            var builder = new RootItemResultBuilder();

            IReadOnlyList<IAttributeUse> attributes;
            {
                var result = itemContext.CommonTypeResolvers.ResolveAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            StructDefinitionContent structContent;
            {
                var result = itemContext.CommonTypeResolvers.ResolveStructDefinitionContent(item.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                structContent = result.Value;
            }

            builder.Item = new StructDefinition(item.ItemId, item.TypeName, structContent, attributes);

            return builder.CreateSuccessResult();
        }

        private IRootItemTypeResolveContext AddTypeNameGenericParamsToContext(
            IRootItemTypeResolveContext itemContext,
            TypedItemName typeName)
        {
            if (!(typeName.ItemNameIdentifier is GenericTypeNameIdentifier genericIdentifier))
            {
                return itemContext;
            }

            throw new NotImplementedException();
        }
    }
}
