using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeNameVisitor : BaseVisitor<TypeName>
    {
        public override TypeName VisitTypeName(DdlParser.TypeNameContext context)
        {
            var identNode = context.Identifier();

            var identifier = new Identifier(identNode.GetText());

            return new TypeName(identifier);
        }
    }
}
