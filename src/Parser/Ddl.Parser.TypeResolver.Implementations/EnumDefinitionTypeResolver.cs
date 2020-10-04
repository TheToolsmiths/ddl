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

            IReadOnlyList<EnumConstantDefinition> constants;
            {
                var result = this.ResolveConstants(updatedItemContext, item.Constants, item.TypeName.ItemName);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                constants = result.Value;
            }

            var typeNameResolution = updatedItemContext.TypeNameResolver.Resolve(item.TypeName);

            builder.Item = new EnumDefinition(item.ItemId, item.TypeName, typeNameResolution, constants, attributes);

            return builder.CreateSuccessResult();
        }

        private Result<IReadOnlyList<EnumConstantDefinition>> ResolveConstants(
            IRootItemTypeResolveContext itemContext,
            IReadOnlyList<EnumConstantDefinition> constants,
            TypeNameIdentifier itemName)
        {
            var resolvedConstants = new List<EnumConstantDefinition>();

            foreach (var constantDefinition in constants)
            {
                var result = this.ResolveConstant(itemContext, constantDefinition, itemName);

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
            EnumConstantDefinition constant,
            TypeNameIdentifier itemName)
        {
            AttributeUseCollection attributes;
            {
                var result = itemContext.CommonTypeResolvers.ResolveAttributes(constant.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var subItemName = new TypedSubItemName(itemName, constant.Name);

            var typeNameResolution = itemContext.TypeNameResolver.Resolve(subItemName);

            var resolvedConstant = new EnumConstantDefinition(constant.SubItemId, constant.Name, typeNameResolution, attributes, constant.Value);

            return Result.FromValue(resolvedConstant);
        }
    }
}
