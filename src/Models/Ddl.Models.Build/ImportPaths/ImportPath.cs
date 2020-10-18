using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.ImportPaths
{
    public class ImportPath : IPath<ImportPathPart>
    {
        private ImportPath(ImmutableArray<string> pathParts, bool isRooted)
        {
            this.PathParts = pathParts.Select(name => new ImportPathPart(name)).ToImmutableArray();
            this.IsRooted = isRooted;
        }

        public ImmutableArray<ImportPathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static ImportPath CreateRooted(IReadOnlyList<string> pathIdentifiers)
        {
            return new ImportPath(pathIdentifiers.ToImmutableArray(), true);
        }

        public static ImportPath CreateNonRooted(IReadOnlyList<string> pathIdentifiers)
        {
            return new ImportPath(pathIdentifiers.ToImmutableArray(), false);
        }

        public static ImportPath CreateRooted(params string[] pathIdentifiers)
        {
            if (pathIdentifiers.Length == 0)
            {
                throw new ArgumentException(nameof(pathIdentifiers));
            }

            return new ImportPath(pathIdentifiers.ToImmutableArray(), true);
        }

        public static ImportPath CreateNonRooted(params string[] pathIdentifiers)
        {
            if (pathIdentifiers.Length == 0)
            {
                throw new ArgumentException(nameof(pathIdentifiers));
            }

            return new ImportPath(pathIdentifiers.ToImmutableArray(), false);
        }

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(this.IsRooted, this.PathParts);
        }
    }
}
