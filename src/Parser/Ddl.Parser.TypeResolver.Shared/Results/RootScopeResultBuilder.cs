using System;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootScopeResultBuilder
    {
        public IRootScope? Scope { get; }

        public RootScopeTypeResolveSuccess CreateSuccessResult()
        {
            if (this.Scope == null)
            {
                throw new NotImplementedException();
            }

            return new RootScopeTypeResolveSuccess(this.Scope);
        }
    }
}
