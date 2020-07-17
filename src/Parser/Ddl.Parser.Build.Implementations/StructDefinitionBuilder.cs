using System;

using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;

using StructDefinitionContent = TheToolsmiths.Ddl.Models.Structs.Content.StructDefinitionContent;

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

            var structDefinition = new StructDefinition(typeName, structContent);

            builder.Items.Add(structDefinition);

            return builder.CreateSuccessResult();
        }
    }
}
