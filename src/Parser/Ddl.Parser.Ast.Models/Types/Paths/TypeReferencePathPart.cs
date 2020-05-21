using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths
{
    public abstract class TypeReferencePathPart
    {
        protected TypeReferencePathPart(Identifier name)
        {
            this.Name = name;
        }

        public abstract TypeReferencePathPartKind PartKind { get; }

        public Identifier Name { get; }

        public static TypeReferencePathPart CreateFromIdentifierPart(TypeIdentifierPathPart identifierPart)
        {
            return identifierPart switch
            {
                GenericIdentifierPathPart genericPart => new GenericReferencePathPart(
                    genericPart.Name,
                    genericPart.GenericParameters.Count),
                SimpleIdentifierPathPart simplePart => new SimpleReferencePathPart(simplePart.Name),
                _ => throw new ArgumentOutOfRangeException(nameof(identifierPart))
            };
        }
    }
}
