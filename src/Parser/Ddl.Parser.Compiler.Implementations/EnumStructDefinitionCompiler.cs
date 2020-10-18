using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Build.Enums;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Enums;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Implementations
{
    internal class EnumStructDefinitionCompiler : IItemCompiler<EnumStructDefinition>
    {
        public RootItemCompileResult CompileItem(
            IRootItemCompileContext itemContext,
            EnumStructDefinition item)
        {
            var updatedItemContext = itemContext.AddTypeNameInfoToContext(item.TypeName);

            var builder = new RootItemResultBuilder();

            IReadOnlyList<CompiledEnumStructVariant> variants;
            {
                var result = this.CompileVariants(updatedItemContext, item.Variants, item.TypeName);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                variants = result.Value;
            }

            CompiledAttributeUseCollection attributes;
            {
                var result = updatedItemContext.CommonCompilers.CompileAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var typeName = updatedItemContext.TypeNameResolver.Resolve(item.TypeName);

            builder.Item = new CompiledEnumStructDefinition(item.ItemId, typeName, variants, attributes);

            return builder.CreateSuccessResult();
        }

        private Result<IReadOnlyList<CompiledEnumStructVariant>> CompileVariants(
            IRootItemCompileContext itemContext,
            IReadOnlyList<EnumStructVariantDefinition> variants,
            ItemTypeName itemName)
        {
            var resolvedVariants = new List<CompiledEnumStructVariant>();

            foreach (var variant in variants)
            {
                var result = this.CompileVariant(itemContext, variant, itemName);

                if (result.IsError)
                {
                    return result.As<IReadOnlyList<CompiledEnumStructVariant>>();
                }

                resolvedVariants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<CompiledEnumStructVariant>>(resolvedVariants);
        }

        private Result<CompiledEnumStructVariant> CompileVariant(
            IRootItemCompileContext itemContext,
            EnumStructVariantDefinition variant,
            ItemTypeName itemName)
        {
            CompiledStructContent content;
            {
                var result = itemContext.CommonCompilers.CompileStructDefinitionContent(variant.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                content = result.Value;
            }

            CompiledAttributeUseCollection attributes;
            {
                var result = itemContext.CommonCompilers.CompileAttributes(variant.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var subItemName = new SubItemTypeName(itemName.ItemName, variant.SubItemName);

            var qualifiedName = itemContext.TypeNameResolver.Resolve(subItemName);

            var resolvedVariant = new CompiledEnumStructVariant(variant.SubItemId, qualifiedName, attributes, content);

            return Result.FromValue(resolvedVariant);
        }
    }
}
