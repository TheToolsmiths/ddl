using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.Structs.Content;
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
            IReadOnlyList<EnumStructVariantDefinition> variants;
            {
                var result = this.ResolveVariants(itemContext, item.Variants);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                variants = result.Value;
            }

            IReadOnlyList<IAttributeUse> attributes;
            {
                var result = itemContext.CommonTypeResolvers.ResolveAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var resolvedItem = new EnumStructDefinition(item.TypeName, variants, attributes);

            return new RootItemTypeResolveSuccess(resolvedItem);
        }

        private Result<IReadOnlyList<EnumStructVariantDefinition>> ResolveVariants(
            IRootItemTypeResolveContext itemContext,
            IReadOnlyList<EnumStructVariantDefinition> variants)
        {
            var resolvedVariants = new List<EnumStructVariantDefinition>();

            foreach (var variant in variants)
            {
                var result = this.ResolveVariant(itemContext, variant);

                if (result.IsError)
                {
                    return result.As<IReadOnlyList<EnumStructVariantDefinition>>();
                }

                resolvedVariants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<EnumStructVariantDefinition>>(resolvedVariants);
        }

        private Result<EnumStructVariantDefinition> ResolveVariant(IRootItemTypeResolveContext itemContext, EnumStructVariantDefinition variant)
        {
            var result = itemContext.CommonTypeResolvers.ResolveStructDefinitionContent(variant.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var content = result.Value;

            var resolvedVariant = new EnumStructVariantDefinition(variant.VariantId, variant.VariantName, content);

            return Result.FromValue(resolvedVariant);
        }
    }
}
