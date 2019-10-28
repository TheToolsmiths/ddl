using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeIdentifierVisitor : BaseVisitor<TypeIdentifier>
    {
        public override TypeIdentifier VisitTypeIdent(DdlParser.TypeIdentContext context)
        {
            var identNodes = context.Ident();

            var identsText = new List<string>();

            foreach (var node in identNodes)
            {
                var nodeText = node.GetText();

                if (string.IsNullOrWhiteSpace(nodeText))
                {
                    throw new ArgumentException();
                }

                identsText.Add(nodeText);
            }

            if (identsText.Count == 0)
            {
                throw new Exception();
            }

            var typeNameText = identsText.Last();

            if (string.IsNullOrWhiteSpace(typeNameText))
            {
                throw new ArgumentException();
            }

            var typeName = new TypeName(typeNameText);

            if (identsText.Count == 1)
            {
                return new TypeIdentifier(typeName);
            }

            var namespaceIdents = identsText.GetRange(0, identsText.Count - 1);

            var namespaceIdentifier = new NamespaceIdentifier(namespaceIdents);

            var typeIdentifier = new TypeIdentifier(typeName, namespaceIdentifier);

            return typeIdentifier;
        }
    }
}
