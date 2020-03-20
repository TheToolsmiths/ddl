using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypeParameterListVisitor : BaseVisitor<IReadOnlyList<ITypeIdentifier>>
    {
        public override IReadOnlyList<ITypeIdentifier> VisitTypeParameterList(DdlParser.TypeParameterListContext context)
        {
            var typeIdentifierContexts = context.typeIdentifier();

            var typeArgumentList = new List<ITypeIdentifier>();

            var visitor = new TypeIdentifierVisitor();

            foreach (var typeIdentifierContext in typeIdentifierContexts)
            {
                var typeIdentifier = visitor.VisitTypeIdentifier(typeIdentifierContext);

                typeArgumentList.Add(typeIdentifier);
            }

            return typeArgumentList;
        }
    }

    public class TypeNameVisitor : BaseVisitor<ITypeName>
    {
        public override ITypeName VisitTypeName(DdlParser.TypeNameContext context)
        {
            var typeArgumentList = context.typeParameterList();

            if (typeArgumentList == null)
            {
                return this.VisitSimpleTypeName(context);
            }

            return this.VisitGenericTypeName(context);
        }

        private GenericTypeName VisitGenericTypeName(DdlParser.TypeNameContext context)
        {
            IReadOnlyList<ITypeIdentifier> typeArgumentList;
            {
                var argumentListContext = context.typeParameterList();

                var visitor = new TypeParameterListVisitor();

                typeArgumentList = visitor.VisitTypeParameterList(argumentListContext);
            }

            var identNode = context.Identifier();

            var identifier = new Identifier(identNode.GetText());

            return new GenericTypeName(identifier, typeArgumentList);
        }

        private SimpleTypeName VisitSimpleTypeName(DdlParser.TypeNameContext context)
        {
            var identNode = context.Identifier();

            var identifier = new Identifier(identNode.GetText());

            return new SimpleTypeName(identifier);
        }
    }
}
