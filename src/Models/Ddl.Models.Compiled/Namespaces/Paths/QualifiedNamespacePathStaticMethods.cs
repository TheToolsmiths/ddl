using System;
using System.Collections.Generic;
using System.Collections.Immutable;

using TheToolsmiths.Ddl.Models.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths
{
    public partial class QualifiedNamespacePath
    {
        public static QualifiedNamespacePath CreateFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new QualifiedNamespacePath(ImmutableArray.CreateRange(identifiers));
        }

        public static RelativeNamespacePath GetRelativePath(QualifiedNamespacePath basePath, QualifiedNamespacePath childPath)
        {
            if (basePath.Identifiers.Length > childPath.Identifiers.Length)
            {
                throw new ArgumentException("Base path is shorter than childPath", nameof(basePath));
            }

            int i = 0;
            for (; i < basePath.Identifiers.Length; i++)
            {
                string parentPart = basePath.Identifiers[i];
                string childPart = childPath.Identifiers[i];

                if (parentPart != childPart)
                {
                    throw new ArgumentException("Base path does not match childPath", nameof(basePath));
                }
            }

            var builder = ImmutableArray.CreateBuilder<string>(childPath.Identifiers.Length - i);
            for (; i < childPath.Identifiers.Length; i++)
            {
                builder.Add(childPath.Identifiers[i]);
            }

            return RelativeNamespacePath.CreateFromIdentifiers(builder.MoveToImmutable());
        }

        public static QualifiedNamespacePath Append(QualifiedNamespacePath namespacePath, string identifier)
        {
            var builder = ImmutableArray.CreateBuilder<string>(namespacePath.Identifiers.Length + 1);

            builder.AddRange(namespacePath.Identifiers);
            builder.Add(identifier);

            return new QualifiedNamespacePath(builder.MoveToImmutable());
        }
    }
}
