using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.TypeBuilders;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class AttributeUseBuilder
    {
        public Result<IReadOnlyList<IAttributeUse>> BuildList(
            IRootEntryBuildContext context,
            IReadOnlyList<IAstAttributeUse> astAttributes)
        {
            var attributes = new List<IAttributeUse>();

            foreach (var astAttribute in astAttributes)
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

            return Result.FromValue<IReadOnlyList<IAttributeUse>>(attributes);
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
            throw new NotImplementedException();
        }

        private Result<IAttributeUse> CreateKeyedStructInitializationAttribute(
            IRootEntryBuildContext context,
            KeyedStructInitializationAstAttributeUse astAttributeUse)
        {
            throw new NotImplementedException();
        }

        private Result<IAttributeUse> CreateKeyedTypedAttribute(
            IRootEntryBuildContext context,
            KeyedTypedAstAttributeUse astAttributeUse)
        {
            throw new NotImplementedException();
        }
    }
}
