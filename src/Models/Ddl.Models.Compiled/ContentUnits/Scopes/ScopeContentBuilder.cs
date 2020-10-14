﻿using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Compiled.ImportPaths;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes
{
    public class ScopeContentBuilder
    {
        public ScopeContent Build()
        {
            var imports = ImportStatementCollection.Create(this.Imports);
            return new ScopeContent(this.Items, this.Scopes, imports);
        }

        public List<ImportStatement> Imports { get; } = new List<ImportStatement>();

        public List<IRootItem> Items { get; } = new List<IRootItem>();

        public List<IRootScope> Scopes { get; } = new List<IRootScope>();
    }
}
