using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FieldNameVisitor : BaseVisitor<FieldName>
    {
        public override FieldName VisitFieldName(DdlParser.FieldNameContext context)
        {
            var identNode = context.Identifier();

            var fieldIdentifier = IdentifierParsers.CreateIdentifier(identNode);

            return new FieldName(fieldIdentifier);
        }
    }
}
