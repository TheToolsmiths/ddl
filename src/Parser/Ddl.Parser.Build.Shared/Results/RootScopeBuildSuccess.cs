using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Results
{
    public class RootScopeBuildSuccess : RootScopeBuildResult
    {
        public RootScopeBuildSuccess(IReadOnlyList<IRootScope> scopes)
            : base(RootScopeBuildResultKind.Success)
        {
            this.Scopes = scopes;
        }

        public IReadOnlyList<IRootScope> Scopes { get; }
    }
}
