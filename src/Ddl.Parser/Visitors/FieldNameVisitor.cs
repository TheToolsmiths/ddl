using System;
using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Utils;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FieldNameVisitor : BaseVisitor<FieldName>
    {
        public override FieldName VisitFieldName(DdlParser.FieldNameContext context)
        {
            var identNode = context.Identifier();

            var fieldIdentifier = IdentifierUtils.CreateIdentifier(identNode);

            return new FieldName(fieldIdentifier);
        }
    }
}
