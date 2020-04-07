using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class QualifiedTypeIdentifierVisitor : BaseVisitor<SimpleTypeIdentifier>
    {
        public override SimpleTypeIdentifier VisitQualifiedTypeIdentifier(DdlParser.QualifiedTypeIdentifierContext context)
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

            throw new System.NotImplementedException();

            //var typeIdentifier = new SimpleTypeIdentifier(typeName, namespacePath);

            //return typeIdentifier;
        }
    }
}
