using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Enums;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class EnumStructDefinitionTypeResolver : IItemTypeResolver<EnumStructDefinition>
    {
        public RootItemTypeResolveResult ResolveItemTypes(
            IRootItemTypeResolveContext itemContext,
            EnumStructDefinition item)
        {
            var updatedItemContext = itemContext.AddTypeNameInfoToContext(item.TypeName);

            IReadOnlyList<EnumStructVariantDefinition> variants;
            {
                var result = this.ResolveVariants(updatedItemContext, item.Variants, item.TypeName.ItemName);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                variants = result.Value;
            }

            AttributeUseCollection attributes;
            {
                var result = updatedItemContext.CommonTypeResolvers.ResolveAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var typeNameResolution = updatedItemContext.TypeNameResolver.Resolve(item.TypeName);

            var resolvedItem = new EnumStructDefinition(item.ItemId, item.TypeName, typeNameResolution, variants, attributes);

            return new RootItemTypeResolveSuccess(resolvedItem);
        }

        private Result<IReadOnlyList<EnumStructVariantDefinition>> ResolveVariants(
            IRootItemTypeResolveContext itemContext,
            IReadOnlyList<EnumStructVariantDefinition> variants,
            TypeNameIdentifier itemName)
        {
            var resolvedVariants = new List<EnumStructVariantDefinition>();

            foreach (var variant in variants)
            {
                var result = this.ResolveVariant(itemContext, variant, itemName);

                if (result.IsError)
                {
                    return result.As<IReadOnlyList<EnumStructVariantDefinition>>();
                }

                resolvedVariants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<EnumStructVariantDefinition>>(resolvedVariants);
        }

        private Result<EnumStructVariantDefinition> ResolveVariant(
            IRootItemTypeResolveContext itemContext,
            EnumStructVariantDefinition variant,
            TypeNameIdentifier itemName)
        {
            StructDefinitionContent content;
            {
                var result = itemContext.CommonTypeResolvers.ResolveStructDefinitionContent(variant.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                content = result.Value;
            }

            AttributeUseCollection attributes;
            {
                var result = itemContext.CommonTypeResolvers.ResolveAttributes(variant.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var subItemName = new TypedSubItemName(itemName, variant.Name);

            var typeNameResolution = itemContext.TypeNameResolver.Resolve(subItemName);

            var resolvedVariant = new EnumStructVariantDefinition(variant.SubItemId, variant.Name, typeNameResolution, attributes, content);

            return Result.FromValue(resolvedVariant);
        }
    }
}
