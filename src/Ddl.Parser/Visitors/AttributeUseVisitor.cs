using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class AttributeUseVisitor : BaseVisitor<IAttributeUse>
    {
        public override IAttributeUse VisitAttrUse(DdlParser.AttrUseContext context)
        {
            {
                var keyedAttrUse = context.keyedAttrUse();

                if (keyedAttrUse != null)
                {
                    var visitor = new KeyedAttributeUseVisitor();

                    return visitor.VisitKeyedAttrUse(keyedAttrUse);
                }
            }

            {
                var typedStructInitUse = context.typedStructInitUse();

                if (typedStructInitUse != null)
                {
                    var visitor = new TypedStructuredInitializationUseVisitor();

                    return visitor.VisitTypedStructInitUse(typedStructInitUse);
                }
            }


            {
                var typedCtorInitUse = context.typedCtorInitUse();

                if (typedCtorInitUse != null)
                {
                    var visitor = new TypedConstructorInitializationUseVisitor();

                    return visitor.VisitTypedCtorInitUse(typedCtorInitUse);
                }
            }

            throw new NotImplementedException();
        }
    }

    public class KeyedAttributeUseVisitor : BaseVisitor<IKeyedAttributeUse>
    {
        public override IKeyedAttributeUse VisitKeyedAttrUse(DdlParser.KeyedAttrUseContext context)
        {
            Identifier key;
            {
                var identNode = context.Identifier();

                key = IdentifierParsers.CreateIdentifier(identNode);
            }

            {
                var literalValueContext = context.literalValue();

                if (literalValueContext != null)
                {
                    var listener = new LiteralListener();

                    ParseTreeWalker.Default.Walk(listener, literalValueContext);

                    if (listener.Value == null)
                    {
                        throw new Exception();
                    }

                    return new KeyedLiteralAttributeUse(key, listener.Value);
                }
            }

            {
                var typedStructInitUse = context.typedStructInitUse();

                TypeIdentifier type;
                {
                    var typeIdentContext = typedStructInitUse.typeIdent();

                    var visitor = new TypeIdentifierVisitor();

                    type = visitor.VisitTypeIdent(typeIdentContext);
                }

                StructValueInitialization initialization;
                {
                    var structInitContext = typedStructInitUse.structValueInitialization();

                    var visitor = new StructValueInitializationVisitor();

                    initialization = visitor.VisitStructValueInitialization(structInitContext);
                }

                return new KeyedTypedAttributeUse(key, type, initialization);
            }
        }
    }

    public class TypedStructuredInitializationUseVisitor : BaseVisitor<ITypedAttributeUse>
    {
        public override ITypedAttributeUse VisitTypedStructInitUse(DdlParser.TypedStructInitUseContext context)
        {
            TypeIdentifier type;
            {
                var typeIdentContext = context.typeIdent();

                var visitor = new TypeIdentifierVisitor();

                type = visitor.VisitTypeIdent(typeIdentContext);
            }

            StructValueInitialization initialization;
            {
                var structInitContext = context.structValueInitialization();

                var visitor = new StructValueInitializationVisitor();

                initialization = visitor.VisitStructValueInitialization(structInitContext);
            }

            return new TypedStructInitializationUse(type, initialization);
        }
    }

    public class TypedConstructorInitializationUseVisitor : BaseVisitor<IAttributeUse>
    {
        public override IAttributeUse VisitTypedCtorInitUse(DdlParser.TypedCtorInitUseContext context)
        {
            TypeIdentifier type;
            {
                var typeIdentContext = context.typeIdent();

                var visitor = new TypeIdentifierVisitor();

                type = visitor.VisitTypeIdent(typeIdentContext);
            }

            ConditionalExpression conditionalExpression;
            {
                var conditionalExpressionContext = context.conditionalExpression();

                var visitor = new ConditionalExpressionVisitor();

                conditionalExpression = visitor.VisitConditionalExpression(conditionalExpressionContext);
            }

            return new ConditionalAttributeUse(type, conditionalExpression);
        }
    }
}
