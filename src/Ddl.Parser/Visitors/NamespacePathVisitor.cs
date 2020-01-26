using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class NamespacePathVisitor : BaseVisitor<NamespacePath>
    {
        public override NamespacePath VisitNamespacePath(DdlParser.NamespacePathContext context)
        {
            var identNodes = context.Identifier();

            var identifiers = new List<Identifier>();

            foreach (var node in identNodes)
            {
                var identifier = IdentifierParsers.CreateIdentifier(node);

                identifiers.Add(identifier);
            }

            return new NamespacePath(identifiers);
        }
    }
}
