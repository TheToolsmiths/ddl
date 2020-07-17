using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public class RootScopeResultBuilder
    {
        public RootScopeResultBuilder()
        {
            this.Scopes = new List<IRootScope>();
        }

        public List<IRootScope> Scopes { get; }

        public RootScopeBuildSuccess CreateSuccessResult()
        {
            return new RootScopeBuildSuccess(this.Scopes);
        }
    }
}
