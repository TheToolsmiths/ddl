using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Values;
using FieldDefinition = System.Reflection.Metadata.FieldDefinition;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class StructDefinitionContentResolver
    {
        // TODO: Adapt into a single Struct Content Builder
        //public Result ResolveStructDefinitionContent(
        //    IScopeItemBuildContext scopeContext,
        //    StructDefinitionContent content)
        //{
        //    var context = new ItemResolveContext();

        //    foreach (var contentItem in content.Items)
        //    {
        //        var result = this.CatalogContentItem(context, scopeContext, contentItem);

        //        if (result.IsError)
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }

        //    throw new NotImplementedException();
        //}

        //private Result<IStructItem> CatalogContentItem(
        //    ItemResolveContext context,
        //    IScopeItemBuildContext scopeContext,
        //    IStructDefinitionItem contentItem)
        //{
        //    return contentItem switch
        //    {
        //        FieldDefinition fieldDefinition => this.CatalogFieldDefinition(context, scopeContext, fieldDefinition),
        //        StructScope structScope => this.CatalogStructScope(context, scopeContext, structScope),
        //        _ => throw new ArgumentOutOfRangeException(nameof(contentItem))
        //    };
        //}

        //private Result<IStructItem> CatalogStructScope(
        //    ItemResolveContext context,
        //    IScopeItemBuildContext scopeContext,
        //    StructScope structScope)
        //{
        //    throw new NotImplementedException();
        //}

        //private Result<IStructItem> CatalogFieldDefinition(
        //    ItemResolveContext context,
        //    IScopeItemBuildContext scopeContext,
        //    FieldDefinition astField)
        //{
        //    TypeReference typeReference = TypeReferenceCreator.CreateFromTypeIdentifier(astField.FieldType);

        //    {
        //        var result = scopeContext.TypeResolver.ResolveTypeReference(typeReference);

        //        if (result.IsError)
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }

        //    ValueInitialization initialization;
        //    {
        //        var result = scopeContext.CommonBuilders.BuildValueInitialization(astField.Initialization);

        //        if (result.IsError)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        initialization = result.Value;
        //    }

        //    IReadOnlyList<IAttributeUse> attributes;
        //    {
        //        var result = scopeContext.CommonBuilders.BuildAttributes(astField.Attributes);

        //        if (result.IsError)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        attributes = result.Value;
        //    }

        //    var fieldDefinition = new StructField(astField.Name.Text, typeReference, initialization, attributes);

        //    return Result.FromValue<IStructItem>(fieldDefinition);
        //}
    }
}
