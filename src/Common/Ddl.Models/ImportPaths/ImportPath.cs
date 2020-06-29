using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.ImportPaths
{
    public class ImportPath
    {
        private ImportPath(IReadOnlyList<string> pathIdentifiers, bool isRooted)
        {
            this.PathIdentifiers = pathIdentifiers;
            this.IsRooted = isRooted;
        }

        public IReadOnlyList<string> PathIdentifiers { get; }

        public bool IsRooted { get; }

        public static ImportPath CreateRooted(IReadOnlyList<string> pathIdentifiers)
        {
            return new ImportPath(pathIdentifiers, isRooted: true);
        }

        public static ImportPath CreateNonRooted(IReadOnlyList<string> pathIdentifiers)
        {
            return new ImportPath(pathIdentifiers, isRooted: false);
        }

        public static ImportPath CreateRooted(params string[] pathIdentifiers)
        {
            if (pathIdentifiers.Length == 0)
            {
                throw new ArgumentException(nameof(pathIdentifiers));
            }

            return new ImportPath(pathIdentifiers, isRooted: true);
        }

        public static ImportPath CreateNonRooted(params string[] pathIdentifiers)
        {
            if (pathIdentifiers.Length == 0)
            {
                throw new ArgumentException(nameof(pathIdentifiers));
            }

            return new ImportPath(pathIdentifiers, isRooted: false);
        }

        public override string ToString()
        {
            return $"{(this.IsRooted ? "::" : "")}{string.Join("::", this.PathIdentifiers)}";
        }
    }
}
