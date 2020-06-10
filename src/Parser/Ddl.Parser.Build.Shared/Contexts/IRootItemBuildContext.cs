using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Build.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Build.Models.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Contexts
{
    public interface IRootItemBuildContext
    {
        List<FirstPhaseResolvedItem> ResolvedItems { get; }

        List<FirstPhaseResolvedScope> ResolvedScopes { get; }

        List<FirstPhaseResolvedImportPath> ResolvedImportPaths { get; }
    }
}
