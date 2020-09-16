using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class EnumDefinitionBuilder : IRootItemBuilder<EnumAstDefinition>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, EnumAstDefinition item)
        {
            var builder = new RootItemResultBuilder();

            var typeName = TypeNameBuilder.CreateItemTypeName(item.TypeName);

            IReadOnlyList<EnumConstantDefinition> constants;
            {
                var result = this.BuildEnumStructContent(itemContext, item.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                constants = result.Value;
            }

            IReadOnlyList<IAttributeUse> attributes;
            {
                var result = itemContext.CommonBuilders.BuildAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var structDefinition = new EnumDefinition(typeName, constants, attributes);

            builder.Items.Add(structDefinition);

            return builder.CreateSuccessResult();
        }

        private Result<IReadOnlyList<EnumConstantDefinition>> BuildEnumStructContent(
            IRootItemBuildContext itemContext,
            EnumDefinitionContent astContent)
        {
            var constants = new List<EnumConstantDefinition>();

            foreach (var astDefinitionItem in astContent.Items)
            {
                var result = astDefinitionItem switch
                {
                    EnumDefinitionConstantDefinition astConstant => this.BuildEnumStructVariantDefinition(
                            itemContext,
                            astConstant),
                    _ => throw new ArgumentOutOfRangeException(nameof(astDefinitionItem))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                constants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<EnumConstantDefinition>>(constants);
        }

        private Result<EnumConstantDefinition> BuildEnumStructVariantDefinition(
            IRootItemBuildContext itemContext,
            EnumDefinitionConstantDefinition astVariant)
        {
            var result = itemContext.CommonBuilders.BuildLiteral(astVariant.LiteralValue);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var literalValue = result.Value;

            var variantName = new SimpleTypeNameIdentifier(astVariant.Name.Text);
            var variant = new EnumConstantDefinition(variantName, literalValue);

            return Result.FromValue(variant);
        }
    }
}
