using System;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ValueInitializationVisitor : BaseVisitor<ValueInitialization>
    {
        public override ValueInitialization VisitValueInitialization(DdlParser.ValueInitializationContext context)
        {
            if (context == null)
            {
                return ValueInitialization.CreateEmpty();
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

                    return ValueInitialization.CreateLiteral(listener.Value);
                }
            }

            {
                var structContext = context.structValueInitialization();

                var visitor = new StructValueInitializationVisitor();

                return visitor.VisitStructValueInitialization(structContext);
            }
        }
    }
}
