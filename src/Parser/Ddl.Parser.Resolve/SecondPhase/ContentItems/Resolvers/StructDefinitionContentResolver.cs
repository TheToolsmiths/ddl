using System;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;

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

        private Result CatalogContentItem(
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

        private Result CatalogStructScope(
            ItemResolveContext context,
            ScopeItemResolveContext scopeContext,
            StructScope structScope)
        {
            throw new NotImplementedException();
        }

        private Result CatalogFieldDefinition(
            ItemResolveContext context,
            ScopeItemResolveContext scopeContext,
            FieldDefinition fieldDefinition)
        {
            var resolvedType = scopeContext.TypeResolver.ResolveType(fieldDefinition.FieldType);

            throw new NotImplementedException();
        }
    }
}
