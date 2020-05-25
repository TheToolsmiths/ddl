using System;
using System.Collections.Generic;

using Ddl.Common;

using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Values;

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
            switch (contentItem)
            {
                case FieldDefinition fieldDefinition:
                    return this.CatalogFieldDefinition(context, scopeContext, fieldDefinition);
                case StructScope structScope:
                    return this.CatalogStructScope(context, scopeContext, structScope);
                default:
                    throw new ArgumentOutOfRangeException(nameof(contentItem));
            }
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
            var resolvedType = scopeContext.TypeResolver.ResolveType(astField.FieldType);

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

            return Result.FromValue<Parser.Models.Structs.IStructItem>(fieldDefinition);
        }
    }
}
