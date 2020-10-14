using System;
using TheToolsmiths.Ddl.Models.Ast.Structs;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Structs;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;

using StructDefinitionContent = TheToolsmiths.Ddl.Models.Build.Structs.Content.StructDefinitionContent;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class StructDefinitionBuilder : IRootItemBuilder<StructAstDefinition>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, StructAstDefinition item)
        {
            var builder = new RootItemResultBuilder();

            var typeName = TypeNameBuilder.CreateItemTypeName(item.TypeName);
            StructDefinitionContent structContent;
            {
                var result = itemContext.CommonBuilders.BuildStructContent(item.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                structContent = result.Value;
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

            var structDefinition = new StructDefinition(typeName, typeNameResolution, structContent, attributes);

            builder.Items.Add(structDefinition);

            return builder.CreateSuccessResult();
        }
    }
}
