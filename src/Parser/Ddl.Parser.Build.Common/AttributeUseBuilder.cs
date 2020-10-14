using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Build.Literals;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class AttributeUseBuilder
    {
        public Result<AttributeUseCollection> BuildList(
            IRootEntryBuildContext context,
            AstAttributeUseCollection astAttributes)
        {
            var attributes = new List<IAttributeUse>();

            foreach (var astAttribute in astAttributes.Items)
            {
                var result = astAttribute switch
                {
                    KeyedTypedAstAttributeUse astAttributeUse => this.CreateKeyedTypedAttribute(
                        context,
                        astAttributeUse),
                    KeyedStructInitializationAstAttributeUse astAttributeUse => this
                        .CreateKeyedStructInitializationAttribute(context, astAttributeUse),
                    KeyedLiteralAstAttributeUse astAttributeUse => this.CreateKeyedLiteralAttribute(
                        context,
                        astAttributeUse),
                    ConditionalAstAttributeUse astAttributeUse => this.CreateConditionalAttribute(
                        context,
                        astAttributeUse),
                    AstTypedStructInitializationUse astAttributeUse => this.CreateTypedStructInitialization(
                        context,
                        astAttributeUse),
                    _ => throw new ArgumentOutOfRangeException(nameof(astAttribute))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes.Add(result.Value);
            }

            return Result.FromValue(AttributeUseCollection.Create(attributes));
        }

        private Result<IAttributeUse> CreateTypedStructInitialization(
            IRootEntryBuildContext context,
            AstTypedStructInitializationUse astAttributeUse)
        {
            var type = TypeReferenceCreator.CreateFromTypeIdentifier(astAttributeUse.Type);

            StructInitialization initialization;
            {
                var result = context.CommonBuilders.BuildStructInitialization(astAttributeUse.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                initialization = result.Value;
            }

            var typedAttribute = new TypedStructInitializationUse(type, initialization);

            return Result.FromValue<IAttributeUse>(typedAttribute);
        }

        private Result<IAttributeUse> CreateConditionalAttribute(
            IRootEntryBuildContext context,
            ConditionalAstAttributeUse astAttributeUse)
        {
            var type = TypeReferenceCreator.CreateFromTypeIdentifier(astAttributeUse.Type);

            ConditionalExpression conditionalExpression;
            {
                var result = context.CommonBuilders.BuildConditionalExpression(astAttributeUse.ConditionalExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                conditionalExpression = result.Value;
            }

            var conditionalAttribute = new ConditionalAttributeUse(type, conditionalExpression);

            return Result.FromValue<IAttributeUse>(conditionalAttribute);
        }

        private Result<IAttributeUse> CreateKeyedLiteralAttribute(
            IRootEntryBuildContext context,
            KeyedLiteralAstAttributeUse astAttributeUse)
        {
            string key = astAttributeUse.Key.Text;

            LiteralValue value;
            {
                var result = context.CommonBuilders.BuildLiteral(astAttributeUse.Literal);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                value = result.Value;
            }

            var attribute = new KeyedLiteralAttributeUse(key, value);

            return Result.FromValue<IAttributeUse>(attribute);
        }

        private Result<IAttributeUse> CreateKeyedStructInitializationAttribute(
            IRootEntryBuildContext context,
            KeyedStructInitializationAstAttributeUse astAttributeUse)
        {
            string key = astAttributeUse.Key.Text;

            StructInitialization initialization;
            {
                var result = context.CommonBuilders.BuildStructInitialization(astAttributeUse.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                initialization = result.Value;
            }

            var attribute = new KeyedStructInitializationAttributeUse(key, initialization);

            return Result.FromValue<IAttributeUse>(attribute);
        }

        private Result<IAttributeUse> CreateKeyedTypedAttribute(
            IRootEntryBuildContext context,
            KeyedTypedAstAttributeUse astAttributeUse)
        {
            string key = astAttributeUse.Key.Text;

            var type = TypeReferenceCreator.CreateFromTypeIdentifier(astAttributeUse.Type);

            StructInitialization initialization;
            {
                var result = context.CommonBuilders.BuildStructInitialization(astAttributeUse.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                initialization = result.Value;
            }

            var attribute = new KeyedTypedAttributeUse(key, type, initialization);

            return Result.FromValue<IAttributeUse>(attribute);
        }
    }
}
