﻿using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths
{
    public class FirstPhaseResolvedImportPath
    {
        public FirstPhaseResolvedImportPath(ResolvedImportRoot importRoot, Identifier aliasIdentifier)
        {
            this.ImportRoot = importRoot;
            this.Alias = aliasIdentifier;
        }

        public ResolvedImportRoot ImportRoot { get; }

        public Identifier Alias { get; }

        public override string ToString()
        {
            return this.ImportRoot.ToString()!;
        }
    }
}
