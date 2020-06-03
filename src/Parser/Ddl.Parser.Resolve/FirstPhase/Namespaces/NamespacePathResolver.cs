using System;
using System.IO;
using System.Linq;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces
{
    public class NamespacePathResolver
    {
        public Result<NamespacePath> ResolveContentUnitNamespace(ContentUnitInfo info)
        {
            var relativePath = info.RelativePath;

            string? relativeDir = Path.GetFileNameWithoutExtension(relativePath.Replace('\\', '/'));

            // TODO: Change to directory name
            //string? relativeDir = Path.GetDirectoryName(relativePath.Replace('\\', '/'));

            if (relativeDir == null)
            {
                throw new NotImplementedException();
            }

            var identifiers = relativeDir.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).Select(Identifier.FromString);

            var path = NamespacePath.CreateRootedFromIdentifiers(identifiers);

            return Result.FromValue(path);
        }
    }
}
