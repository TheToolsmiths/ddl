﻿using System;
using System.IO;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Namespaces
{
    public class NamespacePathResolver
    {
        public Result<RootNamespacePath> ResolveContentUnitNamespace(ContentUnitInfo info)
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
