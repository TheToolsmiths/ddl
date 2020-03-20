using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Arrays;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ArrayTypeIdentifierVisitor : BaseVisitor<ITypeIdentifier>
    {
        public override ITypeIdentifier VisitArrayTypeIdentifier(DdlParser.ArrayTypeIdentifierContext context)
        {
            QualifiedTypeIdentifier typeIdentifier;
            {
                var qualifiedTypeIdentifierContext = context.qualifiedTypeIdentifier();

                var visitor = new QualifiedTypeIdentifierVisitor();

                typeIdentifier = visitor.VisitQualifiedTypeIdentifier(qualifiedTypeIdentifierContext);
            }

            IReadOnlyList<ArraySize> sizes;
            {
                var dimensionsContext = context.arrayDimensionsDefinitions();

                var visitor = new ArrayDimensionsDefinitionListVisitor();

                sizes = visitor.VisitArrayDimensionsDefinitions(dimensionsContext);
            }

            return new ArrayTypeIdentifier(typeIdentifier, sizes);
        }
    }
}
