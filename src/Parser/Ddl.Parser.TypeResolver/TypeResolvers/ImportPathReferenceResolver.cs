using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Extensions;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Models.References.ItemReferences;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    public class ImportPathReferenceResolver
    {
        private readonly IReadOnlyDictionary<string, ImportPathResolution> entries;

        private ImportPathReferenceResolver(IReadOnlyDictionary<string, ImportPathResolution> entries)
        {
            this.entries = entries;
        }

        public ImportPathReferenceResolver()
        {
            this.entries = new Dictionary<string, ImportPathResolution>();
        }

        public bool TryGetImportPathResolve(
            string name,
            [NotNullWhen(returnValue: true)] out ImportPathResolution? importResolution)
        {
            return this.entries.TryGetValue(name, out importResolution);
        }

        public ImportPathReferenceResolver AddImports(
            IScopeTypeReferenceResolver typeReferenceResolver,
            ImportStatementCollection imports)
        {
            if (imports.Items.Count == 0)
            {
                return this;
            }

            var newEntries = this.entries.CopyDictionary();

            foreach (var importStatement in imports.Items)
            {
                var typeResolution = typeReferenceResolver.ResolveImportPath(importStatement.ImportPath);

                var importPathReference = new ItemReference(importStatement.ItemId);

                var importResolution = new ImportPathResolution(typeResolution, importPathReference);

                if (newEntries.TryAdd(importStatement.Alias, importResolution) == false)
                {
                    throw new NotImplementedException();
                }
            }

            return new ImportPathReferenceResolver(newEntries);
        }
    }
}
