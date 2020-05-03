using System;
using System.IO;
using System.Linq;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces
{
    public class NamespacePathResolver
    {
        public Result<FirstPhaseNamespacePath> ResolveContentUnitNamespace(ContentUnitInfo info)
        {
            var relativePath = info.RelativePath;

            string? relativeDir = Path.GetDirectoryName(relativePath.Replace('\\', '/'));

            if (relativeDir == null)
            {
                throw new NotImplementedException();
            }

            var identifiers = relativeDir.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).Select(Identifier.FromString);

            var path = FirstPhaseNamespacePath.FromIdentifiers(identifiers);

            return Result.FromValue(path);
        }
    }
}
