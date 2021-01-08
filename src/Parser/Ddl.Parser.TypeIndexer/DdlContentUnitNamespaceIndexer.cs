using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Namespaces;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlContentUnitNamespaceIndexer
    {
        private readonly NamespacePathResolver namespacePathResolver;

        public DdlContentUnitNamespaceIndexer(NamespacePathResolver namespacePathResolver)
        {
            this.namespacePathResolver = namespacePathResolver;
        }

        public Result<ContentUnitNamespaceIndex> IndexContentUnits(IReadOnlyList<ContentUnit> contentUnits)
        {
            var indexBuilder = new ContentUnitNamespaceIndexBuilder();

            foreach (var contentUnit in contentUnits)
            {
                RootNamespacePath rootNamespace;
                {
                    var result = this.namespacePathResolver.ResolveContentUnitNamespace(contentUnit.Info);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    rootNamespace = result.Value;
                }

                indexBuilder.AddContentUnitNamespace(contentUnit.Id, rootNamespace);
            }

            return Result.FromValue(indexBuilder.Build());
        }

        public Result<ContentUnitNamespaceIndex> IndexContentUnit(ContentUnit contentUnit)
        {
            var indexBuilder = new ContentUnitNamespaceIndexBuilder();

            RootNamespacePath rootNamespace;
            {
                var result = this.namespacePathResolver.ResolveContentUnitNamespace(contentUnit.Info);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                rootNamespace = result.Value;
            }

            indexBuilder.AddContentUnitNamespace(contentUnit.Id, rootNamespace);

            return Result.FromValue(indexBuilder.Build());
        }
    }
}
