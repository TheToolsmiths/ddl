using System;

using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Structs.Content.Builders;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;
using TheToolsmiths.Ddl.Results;

using StructDefinitionContent = TheToolsmiths.Ddl.Models.Structs.Content.StructDefinitionContent;
using ValueInitialization = TheToolsmiths.Ddl.Models.Values.ValueInitialization;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class StructDefinitionContentBuilder
    {
        public Result<StructDefinitionContent> BuildContent(
            IRootEntryBuildContext context,
            Ast.Models.Structs.StructDefinitionContent astContent)
        {
            var builder = new Models.Structs.Content.Builders.StructDefinitionContentBuilder();

            var result = this.BuildStructContent(context, builder, astContent);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var content = builder.Build();

            return Result.FromValue(content);
        }

        private Result BuildStructContent(
            IRootEntryBuildContext context,
            StructDefinitionContentBuilderBase builder,
            Ast.Models.Structs.StructDefinitionContent content)
        {
            foreach (var astItem in content.Items)
            {
                var result = astItem switch
                {
                    FieldDefinition fieldDefinition => this.BuildFieldDefinition(context, builder, fieldDefinition),
                    StructScope structScope => this.BuildScope(context, builder, structScope),
                    _ => throw new ArgumentOutOfRangeException(nameof(astItem))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result BuildScope(
            IRootEntryBuildContext context,
            StructDefinitionContentBuilderBase builder,
            StructScope structScope)
        {
            if (structScope.ConditionalExpression.IsEmpty == false)
            {
                var result = context.CommonBuilders.BuildConditionalExpression(structScope.ConditionalExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                ConditionalExpression expression = result.Value;

                var scopeBuilder = builder.AddConditionalScope(expression);

                this.BuildStructContent(context, scopeBuilder, structScope.Content);
            }
            else
            {
                var scopeBuilder = builder.AddScope();

                this.BuildStructContent(context, scopeBuilder, structScope.Content);
            }

            return Result.Success;
        }

        private Result BuildFieldDefinition(
            IRootEntryBuildContext context,
            StructDefinitionContentBuilderBase builder,
            FieldDefinition fieldDefinition)
        {
            var fieldBuilder = builder.AddField(fieldDefinition.Name.Text);

            {
                var result = context.CommonBuilders.BuildAttributes(fieldDefinition.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var attributes = result.Value;

                fieldBuilder.Attributes.AddRange(attributes);
            }


            if (fieldDefinition.Initialization.Type != ValueInitializationType.Empty)
            {
                ValueInitialization initialization;
                {
                    var result = context.CommonBuilders.BuildValueInitialization(fieldDefinition.Initialization);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    initialization = result.Value;
                }

                fieldBuilder.AddInitialization(initialization);
            }

            var type = TypeReferenceCreator.CreateFromTypeIdentifier(fieldDefinition.FieldType);

            fieldBuilder.WithType(type);

            return Result.Success;
        }
    }
}
