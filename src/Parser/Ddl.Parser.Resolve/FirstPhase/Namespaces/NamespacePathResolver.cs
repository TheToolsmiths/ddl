using System;
using System.IO;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces
{
    public class NamespacePathResolver
    {
        public Result<NamespacePath> ResolveContentUnitNamespace(ContentUnitInfo info)
        {
            var relativePath = info.RelativePath;

            string? relativeDir = Path.GetDirectoryName(relativePath.Replace('\\', '/'));

            if (relativeDir == null)
            {
                throw new NotImplementedException();
            }

            var identifiers = relativeDir.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            var path = NamespacePath.CreateRootedFromIdentifiers(identifiers);

            return Result.FromValue(path);
        }
    }
}
