using System;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ReferenceTypeIdentifierVisitor : BaseVisitor<ReferenceTypeIdentifier>
    {
        public override ReferenceTypeIdentifier VisitReferenceTypeIdentifier(DdlParser.ReferenceTypeIdentifierContext context)
        {
            ReferenceKind referenceKind;
            {
                var foo = context.referencePrefix();

                var visitor = new ReferenceTypePrefixVisitor();

                referenceKind = visitor.VisitReferencePrefix(foo);
            }

            ITypeIdentifier typeIdentifier = null;

            {
                var qualifiedTypeIdentifierContext = context.qualifiedTypeIdentifier();

                if (qualifiedTypeIdentifierContext != null)
                {
                    var visitor = new QualifiedTypeIdentifierVisitor();

                    typeIdentifier = visitor.VisitQualifiedTypeIdentifier(qualifiedTypeIdentifierContext);
                }
            }

            if (typeIdentifier == null)
            {
                var arrayTypeIdentifierContext = context.arrayTypeIdentifier();

                if (arrayTypeIdentifierContext != null)
                {
                    var visitor = new ArrayTypeIdentifierVisitor();

                    typeIdentifier = visitor.VisitArrayTypeIdentifier(arrayTypeIdentifierContext);
                }
            }

            if (typeIdentifier == null)
            {
                throw new ArgumentException();
            }

            return new ReferenceTypeIdentifier(typeIdentifier, referenceKind);
        }
    }
}
