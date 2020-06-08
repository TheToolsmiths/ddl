using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.Common.TypeHelpers
{
    public static class ResolveTypeIdentifierPathBuilder
    {
        public static TypeIdentifierPath Create(NamespacePath namespacePath, ItemTypeName itemTypeName)
        {
            var parts = CreateTypeReferenceParts(namespacePath);

            parts.Add(CreateTypeIdentifierPathPart(itemTypeName.ItemNameIdentifier));

            return namespacePath.IsRooted
                ? TypeIdentifierPath.CreateRootedFromParts(parts)
                : TypeIdentifierPath.CreateFromParts(parts);
        }

        public static TypeIdentifierPath Create(NamespacePath namespacePath, SubItemTypeName subItemTypeName)
        {
            var parts = CreateTypeReferenceParts(namespacePath);

            parts.Add(CreateTypeIdentifierPathPart(subItemTypeName.ItemNameIdentifier));

            parts.Add(CreateTypeIdentifierPathPart(subItemTypeName.SubItemNameIdentifier));

            return namespacePath.IsRooted
                ? TypeIdentifierPath.CreateRootedFromParts(parts)
                : TypeIdentifierPath.CreateFromParts(parts);
        }

        private static TypeIdentifierPathPart CreateTypeIdentifierPathPart(TypeNameIdentifier typeName)
        {
            return typeName switch
            {
                GenericTypeNameIdentifier identifier => new GenericIdentifierPathPart(
                    identifier.Name,
                    identifier.GenericParameters.Count),
                SimpleTypeNameIdentifier identifier => new SimpleIdentifierPathPart(identifier.Name),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static List<TypeIdentifierPathPart> CreateTypeReferenceParts(NamespacePath namespacePath)
        {
            var parts = new List<TypeIdentifierPathPart>();

            foreach (var identifier in namespacePath.Identifiers)
            {
                var pathPart = new SimpleIdentifierPathPart(identifier);

                parts.Add(pathPart);
            }

            return parts;
        }
    }
}
