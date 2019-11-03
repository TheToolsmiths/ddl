using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Utils;

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
                var literalNode = context.Literal();

                if (literalNode != null)
                {
                    var literal = LiteralUtils.CreateLiteralInitialization(literalNode);

                    return ValueInitialization.CreateLiteral(literal);
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
