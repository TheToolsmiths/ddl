using System;
using System.Collections.Generic;

using Ddl.Common;

using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types.References;
using TheToolsmiths.Ddl.Parser.Models.Values;
using TheToolsmiths.Ddl.Resolve.Common.TypeHelpers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class StructDefinitionContentResolver
    {
        public Result ResolveStructDefinitionContent(
            ScopeItemResolveContext scopeContext,
            StructDefinitionContent content)
        {
            var context = new ItemResolveContext();

            foreach (var contentItem in content.Items)
            {
                var result = this.CatalogContentItem(context, scopeContext, contentItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }

        private Result<IStructItem> CatalogContentItem(
            ItemResolveContext context,
            ScopeItemResolveContext scopeContext,
            IStructDefinitionItem contentItem)
        {
            return contentItem switch
            {
                FieldDefinition fieldDefinition => this.CatalogFieldDefinition(context, scopeContext, fieldDefinition),
                StructScope structScope => this.CatalogStructScope(context, scopeContext, structScope),
                _ => throw new ArgumentOutOfRangeException(nameof(contentItem))
            };
        }

        private Result<IStructItem> CatalogStructScope(
            ItemResolveContext context,
            ScopeItemResolveContext scopeContext,
            StructScope structScope)
        {
            throw new NotImplementedException();
        }

        private Result<IStructItem> CatalogFieldDefinition(
            ItemResolveContext context,
            ScopeItemResolveContext scopeContext,
            FieldDefinition astField)
        {
            TypeReference resolvedType = TypeReferenceCreator.CreateFromTypeIdentifier(astField.FieldType);

            resolvedType = scopeContext.TypeResolver.ResolveType(resolvedType.TypePath);

            ValueInitialization initialization;
            {
                var result = scopeContext.CommonResolvers.ResolveValueInitialization(astField.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                initialization = result.Value;
            }

            IReadOnlyList<IAttributeUse> attributes;
            {
                var result = scopeContext.CommonResolvers.ResolveAttributes(astField.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var fieldDefinition = new StructField(astField.Name, resolvedType, initialization, attributes);

            return Result.FromValue<IStructItem>(fieldDefinition);
        }
    }
}
