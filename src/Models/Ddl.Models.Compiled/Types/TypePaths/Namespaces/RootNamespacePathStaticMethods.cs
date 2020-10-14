using System;
using System.Collections.Immutable;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces
{
    public partial class RootNamespacePath : NamespacePath
    {
        public static NamespacePath GetRelativePath(RootNamespacePath basePath, RootNamespacePath childPath)
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

            return CreateFromArray(builder.MoveToImmutable());
        }
    }
}
