using System;
using TheToolsmiths.Ddl.Models.Compiled.Scopes;

namespace TheToolsmiths.Ddl.Parser.Compiler.Results
{
    public class RootScopeResultBuilder
    {
        public ICompiledScope? Scope { get; }

        public RootScopeCompileSuccess CreateSuccessResult()
        {
            if (this.Scope == null)
            {
                throw new NotImplementedException();
            }

            return new RootScopeCompileSuccess(this.Scope);
        }
    }
}
