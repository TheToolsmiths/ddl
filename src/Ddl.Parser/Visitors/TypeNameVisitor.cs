using System;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeNameVisitor : BaseVisitor<TypeName>
    {
        public override TypeName VisitTypeName(DdlParser.TypeNameContext context)
        {
            var identNode = context.Ident();

            string typeName = identNode.GetText();

            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException();
            }

            return new TypeName(typeName);
        }
    }
}
