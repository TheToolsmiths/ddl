using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class EnumDefinitionTypeResolver : IItemTypeResolver<EnumDefinition>
    {
        public RootItemTypeResolveResult ResolveItemTypes(IRootItemTypeResolveContext itemContext, EnumDefinition item)
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

            IReadOnlyList<EnumConstantDefinition> constants;
            {
                var result = this.ResolveConstants(itemContext, item.Constants);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                constants = result.Value;
            }

            builder.Item = new EnumDefinition(item.ItemId, item.TypeName, constants, attributes);

            return builder.CreateSuccessResult();
        }

        private Result<IReadOnlyList<EnumConstantDefinition>> ResolveConstants(
            IRootItemTypeResolveContext itemContext,
            IReadOnlyList<EnumConstantDefinition> constants)
        {
            var resolvedConstants = new List<EnumConstantDefinition>();

            foreach (var constantDefinition in constants)
            {
                var result = this.ResolveConstant(itemContext, constantDefinition);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                resolvedConstants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<EnumConstantDefinition>>(resolvedConstants);
        }

        private Result<EnumConstantDefinition> ResolveConstant(
            IRootItemTypeResolveContext itemContext,
            EnumConstantDefinition constantDefinition)
        {
            // TODO: Resolve enum attributes

            return Result.FromValue(constantDefinition);
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
