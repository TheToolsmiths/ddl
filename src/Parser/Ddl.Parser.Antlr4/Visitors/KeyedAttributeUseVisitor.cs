using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
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

                ITypeIdentifier type;
                {
                    var typeIdentifierContext = typedStructInitUse.typeIdentifier();

                    var visitor = new TypeIdentifierVisitor();

                    type = visitor.VisitTypeIdentifier(typeIdentifierContext);
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
}