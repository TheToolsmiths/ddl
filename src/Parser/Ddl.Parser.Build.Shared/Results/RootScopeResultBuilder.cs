using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Results
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
