using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Common
{
    public class StructDefinitionContentTypeResolver
    {
        public Result<StructDefinitionContent> Resolve(IRootScopeTypeResolveContext context, StructDefinitionContent content)
        {
            var builder = new StructDefinitionContentBuilder();

            var result = this.BuildScopeItems(context, builder, content.Items);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var resolvedContent = builder.Build();

            return Result.FromValue(resolvedContent);
        }

        private Result BuildScopeItems(
            IRootScopeTypeResolveContext context,
            StructDefinitionContentBuilderBase builder,
            IReadOnlyList<IStructDefinitionItem> items)
        {
            foreach (var item in items)
            {
                var result = item switch
                {
                    FieldDefinition field => this.BuildFieldDefinition(context, builder, field),
                    ConditionalScopeDefinition scope => this.ResolveScope(context, builder, scope),
                    ScopeDefinition scope => this.ResolveConditionalScope(context, builder, scope),
                    _ => throw new ArgumentOutOfRangeException(nameof(item))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result ResolveConditionalScope(IRootScopeTypeResolveContext context, StructDefinitionContentBuilderBase builder, ScopeDefinition scope)
        {
            var scopeBuilder = builder.AddScope();

            this.BuildScopeItems(context, scopeBuilder, scope.Items);

            return Result.Success;
        }

        private Result ResolveScope(IRootScopeTypeResolveContext context, StructDefinitionContentBuilderBase builder, ConditionalScopeDefinition scope)
        {
            var scopeBuilder = builder.AddConditionalScope(scope.ConditionalExpression);

            this.BuildScopeItems(context, scopeBuilder, scope.Items);

            return Result.Success;
        }

        private Result BuildFieldDefinition(
            IRootScopeTypeResolveContext context,
            StructDefinitionContentBuilderBase builder,
            FieldDefinition fieldDefinition)
        {
            var fieldBuilder = builder.AddField(fieldDefinition.Name);

            {
                var result = context.CommonTypeResolvers.ResolveAttributes(fieldDefinition.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var attributes = result.Value;

                fieldBuilder.AttributeCollection = attributes;
            }


            if (fieldDefinition.Initialization.InitializationKind != ValueInitializationType.Empty)
            {
                ValueInitialization initialization;
                {
                    var result = context.CommonTypeResolvers.ResolveValueInitialization(fieldDefinition.Initialization);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    initialization = result.Value;
                }

                fieldBuilder.AddInitialization(initialization);
            }

            var type = context.TypeReferenceResolver.Resolve(fieldDefinition.FieldType);

            fieldBuilder.WithType(type);

            return Result.Success;
        }
    }
}
