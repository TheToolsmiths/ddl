using System;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FieldNameVisitor : BaseVisitor<FieldName>
    {
        public override FieldName VisitFieldName(DdlParser.FieldNameContext context)
        {
            var identNode = context.Ident();

            string typeName = identNode.GetText();

            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException();
            }

            return new FieldName(typeName);
        }
    }
}
