using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Extensions;
using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Models.Build.Items.References;

namespace TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers
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
            [NotNullWhen(true)] out ImportPathResolution? importResolution)
        {
            return this.entries.TryGetValue(name, out importResolution);
        }

        public ImportPathReferenceResolver AddImports(
            IScopeTypeUseResolver typeUseResolver,
            ImportStatementCollection imports)
        {
            if (imports.Items.Count == 0)
            {
                return this;
            }

            var newEntries = this.entries.CopyDictionary();

            foreach (var importStatement in imports.Items)
            {
                var typeResolution = typeUseResolver.ResolveImportPath(importStatement.ImportPath);

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
