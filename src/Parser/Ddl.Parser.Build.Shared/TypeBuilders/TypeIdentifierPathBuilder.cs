using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Build.TypeBuilders
{
    public static class TypeIdentifierPathBuilder
    {
        public static TypeIdentifierPath Create(NamespacePath namespacePath, TypedItemName typedItemName)
        {
            var parts = CreateTypeReferenceParts(namespacePath);

            parts.Add(CreateTypeIdentifierPathPart(typedItemName.ItemNameIdentifier));

            return namespacePath.IsRooted
                ? TypeIdentifierPath.CreateRootedFromParts(parts)
                : TypeIdentifierPath.CreateFromParts(parts);
        }

        public static TypeIdentifierPath Create(NamespacePath namespacePath, TypedSubItemName typedSubItemName)
        {
            var parts = CreateTypeReferenceParts(namespacePath);

            parts.Add(CreateTypeIdentifierPathPart(typedSubItemName.ItemNameIdentifier));

            parts.Add(CreateTypeIdentifierPathPart(typedSubItemName.SubItemNameIdentifier));

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
