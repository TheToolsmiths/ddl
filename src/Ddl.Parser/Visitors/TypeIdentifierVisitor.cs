using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeIdentifierVisitor : BaseVisitor<TypeIdentifier>
    {
        public override TypeIdentifier VisitTypeIdent(DdlParser.TypeIdentContext context)
        {
            var identNodes = context.Identifier();

            var identifiers = new List<Identifier>();

            foreach (var node in identNodes)
            {
                var identifier = IdentifierParsers.CreateIdentifier(node);

                identifiers.Add(identifier);
            }

            if (identifiers.Count == 0)
            {
                throw new Exception();
            }

            var typeNameIdentifier = identifiers.Last();

            var typeName = new TypeName(typeNameIdentifier);

            if (identifiers.Count == 1)
            {
                return new TypeIdentifier(typeName);
            }

            var namespaceIdents = identifiers.GetRange(0, identifiers.Count - 1);

            var namespaceIdentifier = new NamespaceIdentifier(namespaceIdents);

            var typeIdentifier = new TypeIdentifier(typeName, namespaceIdentifier);

            return typeIdentifier;
        }
    }
}
