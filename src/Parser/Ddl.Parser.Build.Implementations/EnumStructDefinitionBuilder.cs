using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;
using TheToolsmiths.Ddl.Results;

using EnumStructVariantDefinition = TheToolsmiths.Ddl.Models.Enums.EnumStructVariantDefinition;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class EnumStructDefinitionBuilder : IRootItemBuilder<EnumStructAstDefinition>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, EnumStructAstDefinition item)
        {
            var builder = new RootItemResultBuilder();

            var typeName = TypeNameBuilder.CreateItemTypeName(item.TypeName);

            IReadOnlyList<EnumStructVariantDefinition> variants;
            {
                var result = this.BuildEnumStructContent(itemContext, item.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                variants = result.Value;
            }

            AttributeUseCollection attributes;
            {
                var result = itemContext.CommonBuilders.BuildAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var typeNameResolution = QualifiedItemTypeNameResolution.Unresolved;

            var structDefinition = new EnumStructDefinition(typeName, typeNameResolution, variants, attributes);

            builder.Items.Add(structDefinition);

            return builder.CreateSuccessResult();
        }

        private Result<IReadOnlyList<EnumStructVariantDefinition>> BuildEnumStructContent(
            IRootItemBuildContext itemContext,
            EnumStructAstDefinitionContent astContent)
        {
            var variants = new List<EnumStructVariantDefinition>();

            foreach (var astDefinitionItem in astContent.Items)
            {
                var result = astDefinitionItem switch
                {
                    Ast.Models.Enums.EnumStructVariantDefinition astVariant => this.BuildEnumStructVariantDefinition(
                        itemContext,
                        astVariant),
                    _ => throw new ArgumentOutOfRangeException(nameof(astDefinitionItem))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                variants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<EnumStructVariantDefinition>>(variants);
        }

        private Result<EnumStructVariantDefinition> BuildEnumStructVariantDefinition(
            IRootItemBuildContext itemContext,
            Ast.Models.Enums.EnumStructVariantDefinition astVariant)
        {
            var result = itemContext.CommonBuilders.BuildStructContent(astVariant.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }
            var structContent = result.Value;

            // TODO: Implement parser support for attributes on enum struct variants
            var attributes = AttributeUseCollection.Empty;

            var variantName = new SimpleTypeNameIdentifier(astVariant.Name.Text);

            var variant = new EnumStructVariantDefinition(variantName, attributes, structContent);

            return Result.FromValue(variant);
        }
    }
}
