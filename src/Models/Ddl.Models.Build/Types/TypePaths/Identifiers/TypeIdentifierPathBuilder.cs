using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Identifiers
{
    public static class TypeIdentifierPathBuilder
    {
        public static TypeIdentifierPath Create(RootNamespacePath namespacePath, TypeNameIdentifier typeName)
        {
            var parts = CreateTypeReferenceParts(namespacePath);

            parts.Add(CreateTypeIdentifierPathPart(typeName));

            return namespacePath.IsRooted
                ? TypeIdentifierPath.CreateRootedFromParts(parts)
                : TypeIdentifierPath.CreateFromParts(parts);
        }

        public static TypeIdentifierPath Create(NamespacePath namespacePath, SubItemTypeName typeName)
        {
            var parts = CreateTypeReferenceParts(namespacePath);

            parts.Add(CreateTypeIdentifierPathPart(typeName.ItemName));

            parts.Add(CreateTypeIdentifierPathPart(typeName.SubItemNameIdentifier));

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
