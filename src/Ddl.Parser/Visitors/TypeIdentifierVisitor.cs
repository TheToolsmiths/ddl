using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeIdentifierVisitor : BaseVisitor<TypeIdentifier>
    {
        public override TypeIdentifier VisitTypeIdentifier(DdlParser.TypeIdentifierContext context)
        {
            ITypeName typeName;
            {
                var typeNameContext = context.typeName();

                var visitor = new TypeNameVisitor();

                typeName = visitor.VisitTypeName(typeNameContext);
            }

            NamespacePath namespacePath;
            {
                var namespacePathContext = context.namespacePath();

                if (namespacePathContext == null)
                {
                    namespacePath = NamespacePath.Empty;
                }
                else
                {
                    var visitor = new NamespacePathVisitor();

                    namespacePath = visitor.VisitNamespacePath(namespacePathContext);
                }
            }

            var typeIdentifier = new TypeIdentifier(typeName, namespacePath);

            return typeIdentifier;
        }
    }
}
