using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class StructDefinitionContentResolver
    {
        public Result ResolveStructDefinitionContent(
            IRootItemBuildContext itemContext,
            StructDefinitionContent content)
        {
            var context = new RootItemBuilder();

            foreach (var contentItem in content.Items)
            {
                var result = this.CatalogContentItem(context, itemContext, contentItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }

        private Result<IStructItem> CatalogContentItem(
            RootItemBuilder context,
            IRootItemBuildContext itemContext,
            IStructDefinitionItem contentItem)
        {
            return contentItem switch
            {
                FieldDefinition fieldDefinition => this.CatalogFieldDefinition(context, itemContext, fieldDefinition),
                StructScope structScope => this.CatalogStructScope(context, itemContext, structScope),
                _ => throw new ArgumentOutOfRangeException(nameof(contentItem))
            };
        }

        private Result<IStructItem> CatalogStructScope(
            RootItemBuilder context,
            IRootItemBuildContext itemContext,
            StructScope structScope)
        {
            throw new NotImplementedException();
        }

        private Result<IStructItem> CatalogFieldDefinition(
            RootItemBuilder context,
            IRootItemBuildContext itemContext,
            FieldDefinition astField)
        {
            var typeReference = TypeReferenceCreator.CreateFromTypeIdentifier(astField.FieldType);

            ValueInitialization initialization;
            {
                var result = itemContext.CommonBuilders.BuildValueInitialization(astField.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                initialization = result.Value;
            }

            IReadOnlyList<IAttributeUse> attributes;
            {
                var result = itemContext.CommonBuilders.BuildAttributes(astField.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var fieldDefinition = new StructField(astField.Name.Text, typeReference, initialization, attributes);

            return Result.FromValue<IStructItem>(fieldDefinition);
        }
    }
}
