using System;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeIdentifierVisitor : BaseVisitor<ITypeIdentifier>
    {
        public override ITypeIdentifier VisitTypeIdentifier(DdlParser.TypeIdentifierContext context)
        {
            {
                var qualifiedTypeIdentifierContext = context.qualifiedTypeIdentifier();

                if (qualifiedTypeIdentifierContext != null)
                {
                    var visitor = new QualifiedTypeIdentifierVisitor();

                    return visitor.VisitQualifiedTypeIdentifier(qualifiedTypeIdentifierContext);
                }
            }

            {
                var arrayTypeIdentifierContext = context.arrayTypeIdentifier();

                if (arrayTypeIdentifierContext != null)
                {
                    var visitor = new ArrayTypeIdentifierVisitor();

                    return visitor.VisitArrayTypeIdentifier(arrayTypeIdentifierContext);
                }
            }

            {
                var referenceTypeIdentifierContext = context.referenceTypeIdentifier();

                if (referenceTypeIdentifierContext != null)
                {
                    var visitor = new ReferenceTypeIdentifierVisitor();

                    return visitor.VisitReferenceTypeIdentifier(referenceTypeIdentifierContext);
                }
            }

            throw new NotImplementedException();
        }
    }
}
