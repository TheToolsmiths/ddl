using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Ast.Types.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.Identifiers
{
    public static class QualifiedTypeIdentifierBuilder
    {
        public static QualifiedTypeIdentifier BuildFromParts(IReadOnlyList<TypeIdentifierPathPart> pathParts)
        {
            var typePath = TypeIdentifierPath.CreateFromParts(pathParts);

            return new QualifiedTypeIdentifier(typePath);
        }

        public static QualifiedTypeIdentifier BuildRootedFromParts(IReadOnlyList<TypeIdentifierPathPart> pathParts)
        {
            var typePath = TypeIdentifierPath.CreateRootedFromParts(pathParts);

            return new QualifiedTypeIdentifier(typePath);
        }

        //public static QualifiedTypeIdentifier BuildFromIdentifierList(IReadOnlyList<Identifier> identifiers,
        //    IReadOnlyList<ITypeIdentifier> parameters)
        //{
        //    throw new NotImplementedException();

        //    //var (namespacePath, name) = SplitNamespaceAndIdentifier(identifiers, false);

        //    //return new GenericTypeIdentifier(name, namespacePath, parameters);
        //}

        //public static QualifiedTypeIdentifier BuildRootedFromIdentifierList(
        //    IReadOnlyList<Identifier> identifiers,
        //    IReadOnlyList<ITypeIdentifier> parameters)
        //{
        //    throw new NotImplementedException();

        //    //var (namespacePath, name) = SplitNamespaceAndIdentifier(identifiers, true);

        //    //return new GenericTypeIdentifier(name, namespacePath, parameters);
        //}
    }
}
